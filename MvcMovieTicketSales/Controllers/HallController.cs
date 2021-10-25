using MvcMovieTicketSales.Models;
using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class HallController : Controller
    {
        MovieMvc db = new MovieMvc();
        HallSeat hs = new HallSeat();
        // GET: Hall
        public ActionResult Index()
        {
            hs.hallList = db.Hall.ToList();
            return View(hs);
        }

        [HttpPost]
        public ActionResult HallAdd(Hall hall)
        {
            hall.Status = true;
            hall.CreateDate = DateTime.Now;
            db.Hall.Add(hall);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HallDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var hall = db.Hall.Find(id);
            ViewBag.Hall = hall.Name;

            var detail = db.HallDetail.Where(x => x.HallId == id && x.Status == true).OrderBy(x => x.DateTime).ToList();

            if (hall == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            TempData["Id"] = hall.Id;

            return View(detail);
        }

        [HttpGet]
        public ActionResult HallUpdate(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var hall = db.Hall.Find(id);

            if (hall == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View(hall);
        }

        [HttpPost]
        public ActionResult HallUpdate(int id, Hall hall)
        {
            var key = db.Hall.Find(id);

            key.Name = hall.Name;
            key.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HallMovieAdd()
        {
            HallMovie();

            return View();
        }

        [HttpPost]
        public ActionResult HallMovieAdd(HallDetail hallDetail, Hall hall, Movie movie, MovieFormat movieFormat)
        {
            var hallMovie = db.HallDetail.Where(x => x.HallId == hall.Id).ToList();
            var movieFind = db.Movie.Find(movie.Id);
            foreach (var item in hallMovie)
            {
                string islem = movieFind.Time;
                islem = islem.Replace("dk", "");
                islem = islem.Replace("s", "");
                islem = islem.Replace(" ", "");
                double dk = Convert.ToDouble(islem);
                TimeSpan h = TimeSpan.FromMinutes(dk);
                DateTime ilkTarih = Convert.ToDateTime(item.DateTime);
                DateTime ikinciTarih = Convert.ToDateTime(hallDetail.DateTime);
                //double hours = h.TotalHours;
                //ikinciTarih.AddHours(hours);
                ikinciTarih = ikinciTarih - h;
                TimeSpan sonuc = ilkTarih - ikinciTarih;
                var dakikaFarki = sonuc.TotalMinutes;
                if (dakikaFarki < 0)
                {
                    dakikaFarki = dakikaFarki * -1;
                }

                if (dakikaFarki <= 30) // Dakika farkı 30 olarak ayarlanmıştır
                {
                    ViewBag.Error = "Bu tarih ve saat aralığında bir film seansta mevcuttur.\n Film: " + item.Movie.Name + "";
                    HallMovie();
                    return View();
                }
            }

            if (hall.Id < 0 || movie.Id < 0 || movieFormat.Id < 0)
            {
                ViewBag.Error = "Bilgileri boş bırakamazsınız";
                HallMovie();
                return View();
            }
            else
            {
                hallDetail.HallId = hall.Id;
                hallDetail.MovieId = movie.Id;
                hallDetail.MovieFormatId = movieFormat.Id;
                hallDetail.Status = true;
                hallDetail.CreateDate = DateTime.Now;
                db.HallDetail.Add(hallDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult HallMovieDelete(int id)
        {
            int Id = (int)TempData["Id"];
            var key = db.HallDetail.Find(id);
            db.HallDetail.Remove(key);
            db.SaveChanges();
            return RedirectToAction("HallDetail", "Hall", new { id = Id });
        }

        public void HallMovie()
        {
            string year = DateTime.Now.Year.ToString();

            ViewBag.Hall = new SelectList(db.Hall.OrderBy(x => x.Name), "Id", "Name");
            ViewBag.Movie = new SelectList(db.Movie.Where(x => x.Release.ToString().Contains(year)).OrderBy(x => x.Name), "Id", "Name");
            ViewBag.MovieFormat = new SelectList(db.MovieFormat.OrderBy(x => x.Name), "Id", "Name");
        }
    }
}