using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Google.Protobuf.WellKnownTypes;
using komp.Assets.DbContext;
using komp.Assets.Services;
using komp.Models;
using komp.Models.enumTypes;
using komp.Models.tipai;
using Enum = System.Enum;

namespace komp.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult CreateItem(Item item)
        {

            string path = "";
            string imgpath = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString() + ".jpg";
            try
            {
                if (item.itemPath != null)
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
            
            db.CreateItem(item,imgpath);
            return View("~/Views/Home/NewItem.cshtml");
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

        public ActionResult Items()
        {
            var db = new ApplicationDbItem();
            var list = db.GetItems(10);
            return View("~/Views/Home/Items.cshtml",list);
        }

        public ActionResult DisableItem(int id, bool visible)
        {
            var db = new ApplicationDbItem();
            db.DisableItem(id, visible);
            return RedirectToAction("Items", "Item");
        }
        public ActionResult Item(int id)
        {
            var db = new ApplicationDbItem();
            var item = db.GetItemById(id);
            return View("~/Views/Home/Item.cshtml",item);
        }

    }
}