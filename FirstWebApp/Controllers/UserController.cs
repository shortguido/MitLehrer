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
        public async Task<IActionResult> Index() {
            try
            {
                await rep.ConnectAsync();
                return View(await rep.GetAllUsersAsync());
            }
            catch (DbException)
            {
                return View("Message", new Message("Datenbankfehler", "die Benutzer konnten nicht geladen" +
                    "werden, Versuchen sie es später erneut."));
            }
            finally
            {
                await rep.DisconnectAsync();
            }



        }
        [HttpGet]
        public IActionResult Registration() {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(User userDataFromForm) { 
            if (userDataFromForm == null)
            {
                return RedirectToAction("Registration");

            }
            ValidateRegistrationData(userDataFromForm);
            if (ModelState.IsValid)
            {
                try
                {
                    await rep.ConnectAsync();
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
                catch (DbException)
                {
                    return View("_Message",
                    new Message("Registrierung", "Datenbankfehler!"));
                }


            }

            return View(userDataFromForm);
        }
        private void ValidateRegistrationData(User u) {
            if (u == null)
            {
                return;
            }
            if ((u.Username == null) || (u.Username.Trim().Length <= 4))
            {
                ModelState.AddModelError("Username", "Der Benutzername muss mind 4 Zeichen lang sein");
            }
            if ((u.Password == null) || (u.Password.Length <= 8))
            {
                ModelState.AddModelError("Password", "Das Passwort muss mind 8 Zeichen lang sein");

            }



            if (u.Birthdate >= DateTime.Now)
            {
                ModelState.AddModelError("Birthdate", "Das Geburtsdatum darf sich nicht in der Zukunft befinden");

            }
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
        //hallo das ist nur ein Test
        
    }
}
