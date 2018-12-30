using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutGiydirme.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            object data = 15;
            ViewBag.baslik = "Anasayfa";
            return View(data);
        }

    }
}
