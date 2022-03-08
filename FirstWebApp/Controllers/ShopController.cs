using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers {
    public class ShopController : Controller {
        public IActionResult Index() {
            return View();
        }
        public IActionResult Shop() {
            //Artikel laden zB aus DB
            List<Article> articles = ArticlesFromDB();
            //Artikellist an View übergeben
            return View(articles);
        }
        public IActionResult Basket() {
            return View();
        }

        private List<Article> ArticlesFromDB() {
            //normalerweise werden die Artikel áus der DB geladen
            return new List<Article>()
            {
                new Article()
                {
                    ArticleId=1, Articlename="Iphone", Brand="Apple", ReleaseDate = new DateTime(2021, 10, 1)
                },
                new Article()
                {
                    ArticleId=2, Articlename="Iphone13", Brand="Apple", ReleaseDate = new DateTime(2025, 12, 1)
                }

            };
        }
    }
}
