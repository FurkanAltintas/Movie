using MvcMovieTicketSales.Models;
using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class MovieController : Controller
    {
        MovieMvc db = new MovieMvc();
        MovieCategoryType mct = new MovieCategoryType();
        MovieDirectorWriter mdw = new MovieDirectorWriter();
        WatchList wl = new WatchList();
        // GET: Movie
        [HttpGet]
        public ActionResult Index()
        {
            mct.movieCategory = db.MovieCategory.ToList();
            mct.Movie = db.Movie.ToList();
            mct.movieType = db.MovieType.Where(x => x.Status == true).OrderByDescending(x => x.Id).ToList();
            return View(mct);
        }

        [HttpPost]
        public ActionResult Index(FormCollection movie)
        {
            string mesaj = movie["txtAra"];
            mct.Movie = db.Movie.ToList();
            mct.movieCategory = db.MovieCategory.ToList();
            mct.movieType = db.MovieType.Where(x => x.Movie.Name.Contains(mesaj) && x.Status == true).ToList();
            //var movieList = db.Movie.Where(x => x.Name.Contains(mesaj)).ToList();
            return View(mct);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {

            }

            if (Session.Contents["MId"] != null)
            {
                var key = (int)Session["MId"];
                var information = db.Member.FirstOrDefault(x => x.Id == key);
                mdw.watchList = db.WatchList.Where(x => x.MemberId == information.Id && x.MovieId == id).ToList();
                if (mdw.watchList.Count() > 0)
                {
                    ViewBag.WatchList = "WathcList";
                }
            }

            mdw.movie = db.Movie.Where(x => x.Id == id && x.Status == true).FirstOrDefault();
            mdw.movieType = db.MovieType.Where(x => x.MovieId == id && x.Status == true).ToList();
            mdw.writerDetail = db.WriterDetail.Where(x => x.MovieId == id).ToList();
            mdw.directorDetail = db.DirectorDetail.Where(x => x.MovieId == id && x.Status == true).ToList();
            mdw.celebriteDetail = db.CelebriteDetail.Where(x => x.MovieId == id && x.Status == true).ToList();

            if (mdw.movie == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(mdw);
        }

        public ActionResult Category(int? id)
        {
            if (id == null)
            {

            }

            var category = db.MovieType.Where(x => x.MovieCategoryId == id && x.Status == true).ToList();
            var key = db.MovieCategory.Find(id);
            ViewBag.category = key.Name.ToLower();

            if (category == null)
            {

            }

            return View(category);
        }

        public ActionResult NowPlaying()
        {
            string year = DateTime.Now.Year.ToString();
            var movie = db.MovieType.Where(x => x.Movie.Release.ToString().Contains(year) && x.Status == true).OrderByDescending(x => x.Id).ToList();
            return View(movie);
        }

        public ActionResult ComingSoon()
        {
            string year = DateTime.Now.AddYears(+1).ToString("yyyy");
            var movie = db.MovieType.Where(x => x.Movie.Release.ToString().Contains(year) && x.Status == true).OrderByDescending(x => x.Id).ToList();
            return View(movie);
        }

        public ActionResult WatchListAdd(int id)
        {
            var key = (int)Session["MId"];
            var information = db.Member.FirstOrDefault(x => x.Id == key);
            var watchList = db.WatchList.Where(x => x.MemberId == information.Id && x.MovieId == id).ToList();

            if (watchList.Count == 0)
            {
                wl.MovieId = id;
                wl.MemberId = information.Id;
                db.WatchList.Add(wl);
                db.SaveChanges();
                return RedirectToAction("Details", "Movie", new { id = id });
            }
            else
            {
                var watch = db.WatchList.Where(x => x.MovieId == id).FirstOrDefault();
                var list = db.WatchList.Find(watch.Id);
                db.WatchList.Remove(list);
                db.SaveChanges();
                return RedirectToAction("Details", "Movie", new { id = id });
            }
        }
    }
}