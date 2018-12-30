using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {
        FormExampleDBEntities db = new FormExampleDBEntities();
        public ActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            ViewBag.Mesaj = saat < 12 ? "Günaydın" : "Tünaydın";// ViewBag Controller ve View arasında bilgi taşımaya yarayan çanta
            return View();
        }


        [HttpGet]
        public ActionResult MezuniyetKayitForm() 
        {
            //var model = db.Users.Where(x => x.eposta == Email.Trim()).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult MezuniyetKayitForm(Users user)
        {
            if (ModelState.IsValid)
            {
                db.Database.Connection.Open();
                db.Users.Add(user);
                var model = user;
                db.SaveChanges();
                db.Database.Connection.Close();

                return View("Tesekkur", model);
            }
            else 
            {
            //hata mesajlarını yazdır.
                return View();
            }
        }

        [HttpGet]
        public ActionResult FindRecord() 
        {
          return View();
        }

        [HttpPost]
        public ActionResult FindRecord(string email)
        {
            Users user = db.Users.Where(x => x.eposta == email).FirstOrDefault();
            return View(user);
        }

        [HttpGet]
        public ActionResult BaloList()
        {
            List<Users> users = db.Users.ToList();
            return View(users);
        }
    }
}
