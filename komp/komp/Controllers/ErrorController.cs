using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace komp.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {

            return View("~/Views/Error/NotFound.cshtml");
        }
    }
}