using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovieTicketSales.Models;
using MvcMovieTicketSales.Models.EntityFramework;
using MvcMovieTicketSales.Utils;

namespace MvcMovieTicketSales.Controllers
{
    public class DirectorsController : BaseController
    {
        MovieMvc db = new MovieMvc();
        DirectorInfo dı = new DirectorInfo();
        DirectorDetail dd = new DirectorDetail();
        // GET: Directors
        public ActionResult Index()
        {
            var director = db.Director.ToList();
            return View(director);
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            dı.director = db.Director.Find(id);
            dı.directorDetail = db.DirectorDetail.Where(x => x.DirectorId == id).ToList();

            ViewBag.Movies = new SelectList(db.Movie.OrderBy(x => x.Name), "Id", "Name");

            if (dı.director == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View(dı);
        }

        [HttpPost]
        public ActionResult Detail(int id, Movie movie)
        {
            var key = db.Director.Find(id);

            dd.DirectorId = id;
            dd.MovieId = movie.Id;
            db.DirectorDetail.Add(dd);
            db.SaveChanges();
            return RedirectToAction("Detail");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var director = db.Director.Find(id);

            if (director == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View(director);
        }

        public ActionResult Active(int id)
        {
            var key = db.Director.Find(id);
            key.Status = true;

            var detail = db.DirectorDetail.Where(x => x.DirectorId == id).ToList();

            foreach (var item in detail)
            {
                item.Status = true;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            var key = db.Director.Find(id);
            key.Status = false;

            var detail = db.DirectorDetail.Where(x => x.DirectorId == id).ToList();

            foreach (var item in detail)
            {
                item.Status = false;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Movies(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var movie = db.DirectorDetail.Where(x => x.DirectorId == id && x.Status == true).ToList();
            TempData["Id"] = id;

            if (movie == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }
            return View(movie);
        }

        public ActionResult MovieDelete(int id)
        {
            int Id = (int)TempData["Id"];

            var key = db.DirectorDetail.Where(x => x.MovieId == id && x.DirectorId == Id).FirstOrDefault();

            db.DirectorDetail.Remove(key);
            db.SaveChanges();

            return RedirectToAction("Movies", "Directors", new { id = Id });
        }
    }
}