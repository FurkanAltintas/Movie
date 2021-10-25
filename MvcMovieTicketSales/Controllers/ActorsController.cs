using MvcMovieTicketSales.Models;
using MvcMovieTicketSales.Models.EntityFramework;
using MvcMovieTicketSales.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class ActorsController : BaseController
    {
        MovieMvc db = new MovieMvc();
        CelebriteInfo cı = new CelebriteInfo();
        // GET: Actors
        public ActionResult Index()
        {
            var celebrite = db.Celebrite.ToList();
            return View(celebrite);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            cı.celebrite = db.Celebrite.Where(x => x.Id == id).FirstOrDefault();
            cı.celebriteDetail = db.CelebriteDetail.Where(x => x.CelebriteId == id).ToList();

            if (cı.celebrite == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }
            return View(cı);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var actor = db.Celebrite.Find(id);

            if (actor == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View(actor);
        }

        [HttpPost]
        public ActionResult Update(int id, Movie movie, MovieType movieType)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            //ViewBag.movieCategory = new SelectList(db.MovieCategory, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(Celebrite celebrite, MovieCategory movieCategory)
        {
            db.Celebrite.Add(celebrite);
            return RedirectToAction("Index", "Actors");
        }

        [HttpGet]
        public ActionResult SocialMedia(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var actor = db.Celebrite.Find(id);

            ViewBag.SocialMedia = new SelectList(db.SocialMedia.OrderBy(x => x.Name), "Id", "Name");

            if (actor == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View();
        }

        [HttpPost]
        public ActionResult SocialMedia(int id, CelebriteFollow celebriteFollow, SocialMedia socialMedia)
        {
            celebriteFollow.CelebriteId = id;
            celebriteFollow.SocialMediaId = socialMedia.Id;
            db.CelebriteFollow.Add(celebriteFollow);
            db.SaveChanges();
            return RedirectToAction("SocialMedia", "Actors");
        }

        public ActionResult SocialMediaList(int id)
        {
            var actor = db.Celebrite.Find(id);
            ViewBag.Actor = actor.FullName;

            var social = db.CelebriteFollow.Where(x => x.CelebriteId == id).ToList();
            return View(social);
        }

        [HttpGet]
        public ActionResult SocialMediaUpdate(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var social = db.CelebriteFollow.Find(id);

            ViewBag.SocialMedia = new SelectList(db.SocialMedia.OrderBy(x => x.Name), "Id", "Name");

            if (social == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View(social);
        }

        [HttpPost]
        public ActionResult SocialMediaUpdate(int id, CelebriteFollow celebriteFollow, SocialMedia socialMedia)
        {
            var key = db.CelebriteFollow.Find(id);
            key.SocialMediaId = celebriteFollow.SocialMedia.Id;
            db.SaveChanges();
            return RedirectToAction("SocialMedia", "Actors", new { id = key.Celebrite.Id });
        }

        public ActionResult Movies(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var movie = db.CelebriteDetail.Where(x => x.CelebriteId == id && x.Status == true).ToList();
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

            var key = db.CelebriteDetail.Where(x => x.MovieId == id && x.CelebriteId == Id).FirstOrDefault();

            db.CelebriteDetail.Remove(key);
            db.SaveChanges();

            return RedirectToAction("Movies", "Actors", new { id = Id });
        }
    }
}