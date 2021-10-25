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
    public class CelebritieController : Controller
    {
        MovieMvc db = new MovieMvc();
        CelebriteInfo cı = new CelebriteInfo();
        // GET: Celebritie
        [HttpGet]
        public ActionResult Index()
        {
            var celebritie = db.Celebrite.Where(x => x.Status == true).OrderByDescending(x => x.Id).ToList();
            return View(celebritie);
        }

        [HttpPost]
        public ActionResult Index(FormCollection celebritie)
        {
            string mesaj = celebritie["txtAra"];
            var celebritieList = db.Celebrite.Where(x => x.FullName.Contains(mesaj)).ToList();
            return View(celebritieList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {

            }

            cı.celebrite = db.Celebrite.Where(x => x.Id == id && x.Status == true).FirstOrDefault();
            cı.celebriteFollow = db.CelebriteFollow.Where(x => x.CelebriteId == id).ToList();

            if (cı.celebrite.Birthday != null)
            {
                cı.celebrite.Age = DateTime.Now.Year - cı.celebrite.Birthday.Value.Year;
                db.SaveChanges();
            }


            if (cı.celebrite == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(cı);
        }

        public ActionResult Filmography(int? id)
        {
            if (id == null)
            {

            }

            cı.celebrite = db.Celebrite.Find(id);
            cı.celebriteDetail = db.CelebriteDetail.Where(x => x.CelebriteId == id && x.Status == true).OrderByDescending(x => x.Movie.Release).ToList();

            if (cı.celebriteDetail == null)
            {

            }

            return View(cı);
        }

        public ActionResult NewFilms(int? id)
        {
            if (id == null)
            {

            }

            cı.celebrite = db.Celebrite.Find(id);
            cı.celebriteDetail = db.CelebriteDetail.Where(x => x.CelebriteId == id && x.Status == true).OrderByDescending(x => x.Movie.Release).ToList();

            if (cı.celebriteDetail == null)
            {

            }

            return View(cı);
        }

    }
}