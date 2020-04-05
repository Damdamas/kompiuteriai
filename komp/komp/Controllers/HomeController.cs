using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace komp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var xd = Server.MapPath("~/Assets/constants/connections.txt");
                var lala = new Innit();
                lala.Init(xd);
                var lalalla = "dsadsad";
            var database = "komiuteriu_komponentai";

            string connectionString;
            connectionString = "SERVER=" + lala.ConnectionHost + ";" + "DATABASE=" +
            database + ";" + "UID=" + lala.ConnectionName + ";" + "PASSWORD=" + lala.ConnectionPw + ";";

            var bb = new MySqlConnection(connectionString);
            bb.Open();
            bb.Close();
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
        public ActionResult Pirkti()
        {
            ViewBag.Message = "Your login page";

            return View();
        }
    }
}