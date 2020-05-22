using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using komp.Models;
using komp.Models.tipai;
using Microsoft.Identity;
using komp.Assets.Services;

namespace komp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View("~/Views/Home/login.cshtml");
        }

        [HttpPost]
        [AnonymousAuthorizationFilter]
        public ActionResult Login(User acc)
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
        [UserAuthorizationFilter]
        public ActionResult EditProfileIndex()
        {
            var db = new ApplicationDbUser();
            var usr = db.GetUserById(((User)Session["User"]).id);
            usr.slaptazodis = "";
            return View("~/Views/Home/EditProfile.cshtml", usr);
        }
        public ActionResult EditProfile(User acc)
        {
            bool valid;
            ModelState.Clear();
            if (acc.slaptazodis is null)
            {
                acc.slaptazodis = "123456789";
                valid = TryValidateModel(acc);
                acc.slaptazodis = null;
            }
            else
            {
                valid = TryValidateModel(acc);
                ViewBag.message4 = "4";
            }

            if (!valid)
            {
                ModelState.AddModelError("", "Klaidingi duomenys!");
                return View("~/Views/Home/EditProfile.cshtml", acc);
            }
            var sess = (User)Session["User"];
            acc.id = sess.id;
            acc.role = sess.role;
            var db = new ApplicationDbUser();
            if (acc.slaptazodis is null)
                db.UpdateUser(acc);
            else
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(acc.slaptazodis);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hash = System.Text.Encoding.ASCII.GetString(data);
                acc.slaptazodis = hash;
                db.UpdateUser(acc, acc.slaptazodis);
            }
            acc.slaptazodis = "";
            ViewBag.message5 = "5";
            return View("~/Views/Home/EditProfile.cshtml", acc);
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
        public ActionResult Register(User acc)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Klaidingi duomenys!");
                return View("~/Views/User/Register.cshtml");
            }

            var db = new ApplicationDbUser();
            bool email = false, name = false;
            if (db.EmailExists(acc))
            {
                email = true;
                ViewBag.Message2 = "2";
            }
            if (db.NameExists(acc))
            {
                name = true;
                ViewBag.Message3 = "3";
            }
            if (email || name)
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