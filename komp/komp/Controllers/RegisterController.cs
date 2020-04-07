using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using komp.Models;

namespace komp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(naudotojas acc)
        {
            if(!ModelState.IsValid)
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