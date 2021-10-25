using MvcMovieTicketSales.Models;
using MvcMovieTicketSales.Models.EntityFramework;
using MvcMovieTicketSales.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class MoviesController : BaseController
    {
        MovieFirstType mft = new MovieFirstType();
        MovieMvc db = new MovieMvc();
        MovieCategoryType mct = new MovieCategoryType();
        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movie.OrderByDescending(x => x.Id).ToList();
            return View(movies);

        }

        [HttpGet]
        public ActionResult MovieDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            mft.movie = db.Movie.Find(id);
            mft.movieType = db.MovieType.Where(x => x.MovieId == id).FirstOrDefault();
            mft.celebriteDetail = db.CelebriteDetail.Where(x => x.MovieId == id).ToList();

            ViewBag.Celebrite = new SelectList(db.Celebrite.OrderBy(x => x.FullName), "Id", "FullName");

            if (mft.movie == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View(mft);
        }

        [HttpPost]
        public ActionResult MovieDetail(int id, Celebrite celebrite)
        {
            CelebriteDetail cd = new CelebriteDetail();

            if (celebrite.Id > 0)
            {
                cd.MovieId = id;
                cd.CelebriteId = celebrite.Id;
                db.CelebriteDetail.Add(cd);
                db.SaveChanges();
                return RedirectToAction("MovieDetail", "Movies");
            }
            else
            {
                ViewBag.Celebrite = new SelectList(db.Celebrite.OrderBy(x => x.FullName), "Id", "FullName");
                return RedirectToAction("MovieDetail", "Movies", new { id = id });
            }
        }

        [HttpGet]
        public ActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var movie = db.Movie.Find(id);
            var movietype = db.MovieType.Where(x => x.Movie.Id == id).FirstOrDefault();
            var director = db.DirectorDetail.Where(x => x.MovieId == id).FirstOrDefault();

            mft.movie = db.Movie.Find(id);
            mft.movieType = db.MovieType.Where(x => x.MovieId == id).FirstOrDefault();
            mft.directorDetail = db.DirectorDetail.Where(x => x.MovieId == id).FirstOrDefault();

            if (director != null)
            {
                ViewBag.director = new SelectList(db.Director.OrderBy(x => x.FullName), "Id", "FullName", director.DirectorId);
            }
            else
            {
                ViewBag.director = new SelectList(db.Director.OrderBy(x => x.FullName), "Id", "FullName");
            }

            ViewBag.movieCategory = new SelectList(db.MovieCategory.OrderBy(x => x.Name), "Id", "Name", movietype.MovieCategoryId);

            if (mft.movie == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }
            return View(mft);
        }

        [HttpPost]
        public ActionResult MovieUpdate(int id, Movie movie, MovieType movieType, Director director)
        {
            var key = db.Movie.Find(id);
            var type = db.MovieType.Where(x => x.MovieId == id).FirstOrDefault();

            key.Name = movie.Name;
            key.Time = movie.Time;
            key.Release = movie.Release;
            key.Trailer = movie.Trailer;
            key.Status = true;
            if (movie.Image != null)
            {
                key.Image = movie.Image;
            }
            key.Overview = movie.Overview;
            type.MovieCategoryId = movieType.MovieCategory.Id;

            if (director.Id > 0)
            {
                var directorDetail = db.DirectorDetail.Where(x => x.MovieId == id).FirstOrDefault();
                directorDetail.DirectorId = director.Id;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [HttpGet]
        public ActionResult MovieAdd()
        {
            ViewBag.movieCategory = new SelectList(db.MovieCategory.OrderBy(x => x.Name), "Id", "Name");
            ViewBag.director = new SelectList(db.Director.OrderBy(x => x.FullName), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public ActionResult MovieAdd(Movie movie, MovieCategory movieCategory, Director director)
        {
            MovieType mt = new MovieType();
            DirectorDetail dd = new DirectorDetail();

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                string dosyaAdi = Path.GetFileName(file.FileName);
                string uzanti = Path.GetExtension(file.FileName);
                string adres = "~/Images/Movie/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(adres));
                movie.Image = "/Images/Movie/" + dosyaAdi + uzanti;
                movie.Status = true;
                db.Movie.Add(movie);
                db.SaveChanges();

                mt.MovieCategoryId = movieCategory.Id;
                mt.MovieId = movie.Id;
                db.MovieType.Add(mt);
                db.SaveChanges();

                if (director.Id > 0)
                {
                    dd.MovieId = movie.Id;
                    dd.DirectorId = director.Id;
                    db.DirectorDetail.Add(dd);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                ViewBag.Error = "Bilgileri doldurmayı unutmayın";
                return View();
            }
        }

        [HttpGet]
        public ActionResult MovieDelete(int id)
        {
            var movie = db.Movie.Find(id);
            movie.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Active(int id)
        {
            var key = db.Movie.Find(id);
            key.Status = true;

            var type = db.MovieType.Where(x => x.MovieId == id).ToList();
            var celebrite = db.CelebriteDetail.Where(x => x.MovieId == id).ToList();
            var director = db.DirectorDetail.Where(x => x.MovieId == id).ToList();

            foreach (var item in type)
            {
                item.Status = true;
            }

            foreach (var item in celebrite)
            {
                item.Status = true;
            }

            foreach (var item in director)
            {
                item.Status = true;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            var key = db.Movie.Find(id);
            key.Status = false;

            var type = db.MovieType.Where(x => x.MovieId == id).ToList();
            var celebrite = db.CelebriteDetail.Where(x => x.MovieId == id).ToList();
            var director = db.DirectorDetail.Where(x => x.MovieId == id).ToList();

            foreach (var item in type)
            {
                item.Status = false;
            }

            foreach (var item in celebrite)
            {
                item.Status = false;
            }

            foreach (var item in director)
            {
                item.Status = false;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Category()
        {
            var category = db.MovieCategory.ToList();
            return View(category);
        }

        public ActionResult CategoryDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var category = db.MovieCategory.Find(id);
            ViewBag.Category = category.Name;
            var movieCategory = db.MovieType.Where(x => x.MovieCategoryId == id).ToList();

            if (category == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }
            return View(movieCategory);
        }

        [HttpGet]
        public ActionResult CategoryUpdate(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var category = db.MovieCategory.Find(id);

            if (category == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(int id, MovieCategory category)
        {
            var key = db.MovieCategory.Find(id);

            key.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("Category", "Movies");
        }

        public ActionResult Slider(int id)
        {
            var movie = db.Movie.Find(id);

            if (movie.Slider == true)
            {
                movie.Slider = false;
            }
            else
            {
                movie.Slider = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet]
        public ActionResult MovieActor()
        {
            ViewBag.Movie = new SelectList(db.Movie.OrderBy(x => x.Name), "Id", "Name");
            ViewBag.Celebrite = new SelectList(db.Celebrite.OrderBy(x => x.FullName), "Id", "FullName");

            return View();
        }

        [HttpPost]
        public ActionResult MovieActor(Movie movie, Celebrite celebrite)
        {
            if (movie.Id <= 0 || celebrite.Id <= 0)
            {
                ViewBag.Error = "Seçim yapmanız gerekmektedir";
                ViewBag.Movie = new SelectList(db.Movie.OrderBy(x => x.Name), "Id", "Name");
                ViewBag.Celebrite = new SelectList(db.Celebrite.OrderBy(x => x.FullName), "Id", "FullName");
                return View();
            }
            else
            {
                CelebriteDetail cd = new CelebriteDetail();
                cd.CelebriteId = celebrite.Id;
                cd.MovieId = movie.Id;
                db.CelebriteDetail.Add(cd);
                db.SaveChanges();
                return RedirectToAction("MovieActor", "Movies");
            }
        }

        [HttpGet]
        public ActionResult MovieDirector()
        {
            ViewBag.Movie = new SelectList(db.Movie.OrderBy(x => x.Name), "Id", "Name");
            ViewBag.Director = new SelectList(db.Director.OrderBy(x => x.FullName), "Id", "FullName");

            return View();
        }

        [HttpPost]
        public ActionResult MovieDirector(Movie movie, Director director)
        {
            if (movie.Id <= 0 || director.Id <= 0)
            {
                ViewBag.Error = "Seçim yapmanız gerekmektedir";
                ViewBag.Movie = new SelectList(db.Movie.OrderBy(x => x.Name), "Id", "Name");
                ViewBag.Director = new SelectList(db.Director.OrderBy(x => x.FullName), "Id", "FullName");
                return View();
            }
            else
            {
                DirectorDetail dd = new DirectorDetail();
                dd.DirectorId = director.Id;
                dd.MovieId = movie.Id;
                db.DirectorDetail.Add(dd);
                db.SaveChanges();
                return RedirectToAction("MovieDirector", "Movies");
            }
        }
    }
}