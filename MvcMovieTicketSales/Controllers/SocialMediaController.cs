using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovieTicketSales.Models.EntityFramework;
using MvcMovieTicketSales.Utils;
using MvcMovieTicketSales.Models;

namespace MvcMovieTicketSales.Controllers
{
    public class SocialMediaController : BaseController
    {
        MovieMvc db = new MovieMvc();
        Social s = new Social();
        // GET: SocialMedia
        public ActionResult Index()
        {
            s.socialMediaList = db.SocialMedia.ToList();
            return View(s);
        }

        //index detay guncelle ekle sil

        public ActionResult Detail(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var socialMedia = db.SocialMedia.Find(id);
            ViewBag.SocialMedia = socialMedia.Name;

            var social = db.CelebriteFollow.Where(x => x.SocialMediaId == id && x.SocialMedia.Status == true).ToList();

            if (socialMedia == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View(social);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var social = db.SocialMedia.Find(id);

            if (social == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View(social);
        }

        [HttpPost]
        public ActionResult Update(int id, SocialMedia socialMedia)
        {
            var social = db.SocialMedia.Find(id);
            social.Name = socialMedia.Name;
            db.SaveChanges();
            return RedirectToAction("Index", "SocialMedia");
        }

        [HttpPost]
        public ActionResult Add(SocialMedia socialMedia)
        {
            db.SocialMedia.Add(socialMedia);
            db.SaveChanges();
            return RedirectToAction("Index", "SocialMedia");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var social = db.SocialMedia.Find(id);

            var celebrite = db.CelebriteFollow.Where(x => x.SocialMediaId == id).ToList();

            var employee = db.EmployeeFollow.Where(x => x.SocialMediaId == id).ToList();

            foreach (var item in celebrite)
            {
                db.CelebriteFollow.Remove(item);
            }

            foreach (var item in employee)
            {
                db.EmployeeFollow.Remove(item);
            }

            db.SocialMedia.Remove(social);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            var social = db.SocialMedia.Find(id);
            social.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            var social = db.SocialMedia.Find(id);
            social.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}