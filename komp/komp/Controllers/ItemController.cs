﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using komp.Assets.DbContext;
using komp.Assets.Services;
using komp.Models;
using komp.Models.tipai;

namespace komp.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult CreateItem(Item item)
        {
            var db = new ApplicationDbItem();
            item.tipas = ItemType.Cooler;
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