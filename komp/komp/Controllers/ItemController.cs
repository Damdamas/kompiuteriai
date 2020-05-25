using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using Google.Protobuf.WellKnownTypes;
using komp.Assets.DbContext;
using komp.Assets.Services;
using komp.Models;
using komp.Models.enumTypes;
using komp.Models.tipai;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Enum = System.Enum;

namespace komp.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        private bool guide = false;
        public class dropdown
        {
            public string value { get; set; }
        }
        public ActionResult CreateItem(Item item)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Klaidingi duomenys!");
                return View("~/Views/Home/NewItem.cshtml");
            }
            string path = "";
            string imgpath = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString() + ".jpg";
            try
            {
                if (!(item.itemPath is null))
                {
                    string pic = System.IO.Path.GetFileName(item.itemPath.FileName);
                    // file is uploaded

                    path = System.IO.Path.Combine(
                        Server.MapPath("~/Assets/images/Items"),
                        imgpath);
                    item.itemPath.SaveAs(path);

                }
                var tipas = (enumItemType)Enum.Parse(typeof(enumItemType), item.tipas, true);
                item.tipas = tipas
                                 .GetType()
                                 .GetMember(tipas.ToString())
                                 .FirstOrDefault()
                                 ?.GetCustomAttribute<DescriptionAttribute>()
                                 ?.Description
                             ?? tipas.ToString();
            }
            catch (Exception e)
            {

                throw;
            }

            var db = new ApplicationDbItem();

            db.CreateItem(item, imgpath);
            return RedirectToAction("ItemList");
        }
        [AdminAuthorizationFilter]
        public ActionResult NewItem()
        {
            return View("~/Views/Home/NewItem.cshtml");
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                    Server.MapPath("~/images/Items"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("NewItem", "Item");
        }

        public ActionResult ItemList()
        {
            var db = new ApplicationDbItem();
            var list = db.GetItems(1000);
            return View("~/Views/Home/ItemList.cshtml", list);
        }

        public ActionResult DisableItem(Item item)
        {
            var db = new ApplicationDbItem();
            db.DisableItem(item.id, item.matomas);
            item.matomas = !item.matomas;
            return RedirectToAction("Item", "Item", item);
        }
        public ActionResult Item(int id)
        {
            var db = new ApplicationDbItem();
            var item = db.GetItemById(id);
            return View("~/Views/Home/Item.cshtml", item);
        }

        public ActionResult EditItem(Item item)
        {
            var db = new ApplicationDbItem();
            var itm = db.GetItemById(item.id);
            string path = item.path;
            if (item.tipas is null)
                item.tipas = itm.tipas;
            string imgpath = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString() + ".jpg";
            try
            {
                if (!(item.itemPath is null))
                {
                    string pic = System.IO.Path.GetFileName(item.itemPath.FileName);
                    // file is uploaded

                    path = System.IO.Path.Combine(
                        Server.MapPath("~/Assets/images/Items"),
                        imgpath);
                    item.itemPath.SaveAs(path);
                    item.path = imgpath;
                }
                else
                    item.path = itm.path;
                if (!(item.tipas is null))
                {
                    var tipas = (enumItemType)Enum.Parse(typeof(enumItemType), item.tipas, true);
                    item.tipas = tipas
                                     .GetType()
                                     .GetMember(tipas.ToString())
                                     .FirstOrDefault()
                                     ?.GetCustomAttribute<DescriptionAttribute>()
                                     ?.Description
                                 ?? tipas.ToString();
                }
            }
            catch (Exception e)
            {

                throw;
            }
            db.UpdateItem(item, item.path);
            if (!itm.path.Equals(item.path))
                if (!(path is null))
                {
                    db.UpdateItem(item, imgpath);
                    System.IO.File.Delete(itm.path = System.IO.Path.Combine(
                        Server.MapPath("~/Assets/images/Items"),
                        itm.path));
                }

            return RedirectToAction("ItemList");
        }

        public ActionResult EditItemIndex(Item item)
        {
            return View("~/Views/Home/EditItem.cshtml", item);
        }

        public ActionResult ToCart(Item item)
        {
            if (Session["Cart"] is null)
            {
                Session["Cart"] = new Cart();
                var bask = (Cart)Session["Cart"];
                bask.prekes.Add(item);
                Session["Cart"] = bask;
            }
            else
            {
                var bask = (Cart)Session["Cart"];
                bask.prekes.Add(item);
                Session["Cart"] = bask;
            }
            if (guide)
            {
                Guide(item);
            }
            return RedirectToAction("ItemList");
        }
        public ActionResult Filter(object value)
        {
            var db = new ApplicationDbItem();

            if (((string[])value)[0].Equals(""))
            {
                return View("~/Views/Home/ItemList.cshtml", db.GetItems(1000));
            }

            var cc = EnumHelper.GetSelectList(typeof(enumItemType))[Int32.Parse(((string[])value)[0])].Text;
            var list = from d in db.GetItems(10000)
                       orderby d.kaina
                       where d.tipas == cc
                       select d;

            return View("~/Views/Home/ItemList.cshtml", list);
        }
        public void Guide(Item item)
        {
            var bask = (Cart)Session["Cart"];

        }
        private void GetAtributes(Item item)
        {
            string atributes = item.aprasymas;

        }
    }
}