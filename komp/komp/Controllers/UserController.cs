using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using komp.Models;

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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(naudotojas acc)
        {
            var app = new ApplicationDbUser();
            var usr = app.GetUser(acc);
            if(!(usr.vardas is null))
            Session["UserID"] = Guid.NewGuid();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Verify(naudotojas acc)
        {
            return View();
        }
        public ActionResult IndexRegister()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(naudotojas acc)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "adfdghdghgdhgdhdgda");
                return View("~/Views/User/Register.cshtml");
            }
            var db = new ApplicationDbUser();
            db.CreateUser(acc);

            return View("~/Views/User/Register.cshtml");
        }

    }
}