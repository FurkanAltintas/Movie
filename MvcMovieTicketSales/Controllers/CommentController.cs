using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class CommentController : Controller
    {
        MovieMvc db = new MovieMvc();
        // GET: Contact
        [HttpGet]
        public PartialViewResult Index(int id)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Index(int id, Comment p)
        {
            p.MovieId = id;
            p.Status = false;
            p.History = DateTime.Now;
            db.Comment.Add(p);
            db.SaveChanges();
            TempData["Message"] = id;
            return RedirectToAction("Details", "Movie", new { id = id });
        }

        public PartialViewResult List(int id)
        {
            var list = db.Comment.Where(x=>x.MovieId == id && x.Status == true).ToList();
            return PartialView(list);
        }
    }
}