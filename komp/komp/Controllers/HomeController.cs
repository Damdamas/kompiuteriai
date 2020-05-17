using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using komp.Models;
using komp.Assets.Services;

namespace komp.Controllers
{
    
    public class HomeController : Controller
    {
        //[MyAuthorizationFilter] sita uzdet ant tu metodu, kuriem reiks auth
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
        [AnonymousAuthorizationFilter]
        public ActionResult Login()
        {
            ViewBag.Message = "Your login page";
            User acc = new User();
            return View(acc);
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
        public ActionResult Order()
        {
            ViewBag.Message = "Your login page";

            return View();
        }
    }
}