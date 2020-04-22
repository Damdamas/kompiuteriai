using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using komp.Assets.DbContext;
using komp.Assets.Services;
using komp.Models;
using komp.Models.enumTypes;
using komp.Models.tipai;

namespace komp.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult CreateItem(Item item)
        {
            var tipas = (enumItemType)Enum.Parse(typeof(enumItemType), item.tipas,true);
            item.tipas = tipas
                             .GetType()
                             .GetMember(tipas.ToString())
                             .FirstOrDefault()
                             ?.GetCustomAttribute<DescriptionAttribute>()
                             ?.Description
                         ?? tipas.ToString();

            var db = new ApplicationDbItem();
            db.CreateItem(item);
            return View("~/Views/Home/NewItem.cshtml");
        }
        [AdminAuthorizationFilter]
        public ActionResult NewItem()
        {
            return View("~/Views/Home/NewItem.cshtml");
        }
    }
}