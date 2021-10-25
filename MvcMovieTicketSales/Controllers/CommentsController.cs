using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcMovieTicketSales.Controllers
{
    public class CommentsController : Controller
    {
        MovieMvc db = new MovieMvc();
        // GET: Comments
        public ActionResult Index()
        {
            var list = db.Comment.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var key = Action(id);
            return View(key);
        }

        [HttpPost]
        public ActionResult Update(Comment p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var key = Action(id);
            db.Comment.Remove(key);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public Comment Action(int id)
        {
            return db.Comment.Find(id);
        }

        public ActionResult Active(int id)
        {
            Status(id);
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            Status(id);
            return RedirectToAction("Index");
        }

        public void Status(int id)
        {
            var key = Action(id);
            if (key.Status == true)
            {
                key.Status = false;
            }
            else
            {
                key.Status = true;
            }
            db.SaveChanges();
        }
    }
}