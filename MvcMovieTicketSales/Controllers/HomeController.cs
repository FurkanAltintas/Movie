using MvcMovieTicketSales.Models;
using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MvcMovieTicketSales.Utils;

namespace MvcMovieTicketSales.Controllers
{
    public class HomeController : Controller
    {
        MovieMvc db = new MovieMvc();
        MovieActor ma = new MovieActor();
        MovieCategoryType mct = new MovieCategoryType();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            ma.movie = db.Movie.Where(x => x.Slider == true).OrderByDescending(x => x.Id).Take(3).ToList();
            ma.celebriteDetail = db.CelebriteDetail.Take(7).ToList();

            return View(ma);
        }

        public ActionResult Movie()
        {
            ViewBag.ComingSoon = DateTime.Now.Year + 1;

            mct.movieCategory = db.MovieCategory.ToList();
            mct.movieType = db.MovieType.Where(x => x.Status == true).OrderByDescending(x => x.Id).ToList();
            return View(mct);
        }

        public ActionResult Video()
        {
            var movie = db.Movie.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(movie);
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Subscribe()
        {
            return View();
        }
    }
}