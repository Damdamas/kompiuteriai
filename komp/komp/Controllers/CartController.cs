using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using komp.Models;

namespace komp.Controllers
{
    public class CartController : Controller
    {
        // GET: Basket
        public ActionResult Index()
        {
            if (Session["Cart"] is null)
            {
                Session["Cart"] = new Cart();
            }

            return View("~/Views/Home/Cart.cshtml", (Cart)Session["Cart"]);
        }


    }
}