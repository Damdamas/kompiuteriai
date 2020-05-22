using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using komp.Assets.DbContext;
using komp.Models;

namespace komp.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index(int ItemId)
        {
            var db = new ApplicationDbComment();
            var comments = db.SelectCommentsByItem(ItemId);
            return View("Comments",comments);
        }
        [HttpPost]
        public ActionResult Create(Comment comment, int itemId, int userId)
        {

            var db = new ApplicationDbComment();
            db.CreateComment(comment,userId,itemId);
            return RedirectToAction("Item","Item", new {id = itemId});
        }

    }
}