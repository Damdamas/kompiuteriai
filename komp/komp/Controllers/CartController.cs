using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using komp.Assets.DbContext;
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
        public ActionResult Buy()
        {
            return View("Purchase");
        }
        public ActionResult CompleteBuy(Order order)
        {
            var db = new ApplicationDbCart();
            var dbOrder = new ApplicationDbOrder();
            Cart crt = (Cart)Session["Cart"];
<<<<<<< HEAD
            crt.id = order.krepselisId;
            db.createCart(crt);
            dbOrder.createOrder(order);
=======


>>>>>>> e80ab15b22eb49c3152c9d913a00cc8c02e8bf74
            return View("~/Views/Home/Index.cshtml");
        }

    }
}