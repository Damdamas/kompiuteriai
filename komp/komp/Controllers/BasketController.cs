using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using komp.Models;

namespace komp.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public ActionResult Index()
        {
            if (Session["Basket"] is null)
            {
                Session["Basket"] = new Basket();
            }

            return View("~/Views/Home/Basket.cshtml", (Basket)Session["Basket"]);
        }


    }
}