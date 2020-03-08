using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace komp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your login page";

            return View();
        }
        public ActionResult Items()
        {
            ViewBag.Message = "Your login page";

            return View();
        }
        public ActionResult Item()
        {
            ViewBag.Message = "Your login page";

            return View();
        }
        public ActionResult Basket()
        {
            ViewBag.Message = "Your login page";

            return View();
        }
    }
}