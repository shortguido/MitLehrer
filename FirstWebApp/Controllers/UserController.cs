using FirstWebApp.Models;
using FirstWebApp.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers {
    public class UserController : Controller {

        private RepositoryUserDB rep = new RepositoryUsersDB();
        public IActionResult Index() {
            try
            {
                rep.Connect();
                //Liste mit allen Usern an die View übergeben
                return View(rep.GetAllUsers());
            }
            catch (DbException)
            {
                return View("Message", new Message("Datenbankfehler", "die Benutzer konnten nicht geladen" +
                    "werden, Versuchen sie es später erneut."));
            }
            finally
            {
                rep.Disconnect();
            }

            //erzeugen eine Instanz vom typ user und übergeben sie an die zugehörige View


        }
        [HttpGet]
        public IActionResult Registration() {

            return View();
        }
        [HttpPost]
        public IActionResult Registration(User userDataFromForm) {
            //Parameter überprüfen
            if (userDataFromForm == null)
            {
                //weiterleitung an eine Methode (Action) in selben Controller
                return RedirectToAction("Registration");

            }
            //Eingaben des Benutzers überprüfen
            ValidateRegistrationData(userDataFromForm);
            //falls das Formulas richtig ausgefüllt wurde
            if (ModelState.IsValid)
            {
                try
                {
                    rep.Connect();
                    if (rep.Insert(userDataFromForm))
                    {
                        return View("_Message",
              new Message("Registrierung", "Ihre Daten wurden erfolgreich abgespeichert"));
                    }
                    else
                    {
                        return View("_Message",
                        new Message("Registrierung", "Ihre Daten wurden NICHT erfolgreich abgespeichert",
                        "Bitte versuchen Sie später erneut!"));
                    }
                }
                //Basisklasse der Datenbank-Exceptions
                catch (DbException)
                {
                    return View("_Message",
                    new Message("Registrierung", "Datenbankfehler!"));
                }


            }

            //falls etwas falsch eingeg wurde wird das Reg-Formular neu ausgeführt
            return View(userDataFromForm);
        }
        private void ValidateRegistrationData(User u) {
            //Parameter überprüfen
            if (u == null)
            {
                return;
            }
            //Username
            if ((u.Username == null) || (u.Username.Trim().Length <= 4))
            {
                ModelState.AddModelError("Username", "Der Benutzername muss mind 4 Zeichen lang sein");
            }
            //Password
            if ((u.Password == null) || (u.Password.Length <= 8))
            {
                ModelState.AddModelError("Password", "Das Passwort muss mind 8 Zeichen lang sein");

            }
            //+min ein Großbuchstabe + mind ein Kleinbuchstabe + mind ein Sonderzeichen + mind eine Zahl


            //Email

            //Gebdat
            if (u.Birthdate >= DateTime.Now)
            {
                ModelState.AddModelError("Birthdate", "Das Geburtsdatum darf sich nicht in der Zukunft befinden");

            }
            //Gender
        }
        public IActionResult Login() {
            return View();
        }

        public IActionResult Delete(int id) {
            //user mit der Id löschen
            return View();
        }

        public IActionResult Update(int id) {
            //user mit der Id ändern
            return View();
        }
        
    }
}
