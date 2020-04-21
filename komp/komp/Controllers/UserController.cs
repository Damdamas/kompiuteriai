using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using komp.Models;
using Microsoft.Identity;

namespace komp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            //pasiemam is duombazes
            //sukuriam lista
            //  |
            //  V
            return View("~/Views/Home/login.cshtml");
        }
        [HttpPost]
        public ActionResult Login(naudotojas acc)
        {
            if (acc.slaptazodis is null || acc.elpastas is null)
            {
                return View("~/Views/Home/login.cshtml");
            }
            var app = new ApplicationDbUser();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(acc.slaptazodis);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            acc.slaptazodis = hash;
            var usr = app.GetUser(acc);
            if (usr.id != 0)
            {
                Session["User"] = usr.SessionUser();
                Session["Name"] = usr.vardas + " " + usr.pavarde;
                Session["Role"] = usr.role;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("password", "The username or password is incorrect");
                return View("~/Views/Home/login.cshtml");
            }
        }
        public ActionResult Verify(naudotojas acc)
        {
            return View();
        }
         public ActionResult Register()
        {
            return View();
        }
        public ActionResult IndexRegister()
        {
            return View("Register");
        }
        public ActionResult LogOut()
        {
            Session["Role"] = null;
            Session["User"] = null;
            Session["Name"] = null;
            return View("~/Views/Home/Index.cshtml");
        }
        [HttpPost]
        public ActionResult Register(naudotojas acc)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Klaidingi duomenys!");
                return View("~/Views/User/Register.cshtml");
            }

            var db = new ApplicationDbUser();
            bool email = false, name = false;
            if(db.EmailExists(acc))
            {
                email = true;
                ViewBag.Message2 = "2";
            }
            if(db.NameExists(acc))
            {
                name = true;
                ViewBag.Message3 = "3";
            }
            if(email || name)
                return View("~/Views/User/Register.cshtml");

            byte[] data = System.Text.Encoding.ASCII.GetBytes(acc.slaptazodis);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            acc.slaptazodis = hash;
            db.CreateUser(acc);

            ViewBag.Message = "1";

            return View("~/Views/Home/Index.cshtml");
        }

    }
}