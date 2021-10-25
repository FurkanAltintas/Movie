using MvcMovieTicketSales.Models;
using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class TicketController : Controller
    {
        MovieMvc db = new MovieMvc();
        MovieTicket mt = new MovieTicket();
        TicketSeat ts = new TicketSeat();
        // GET: Ticket
        public ActionResult Index(int? id)
        {
            if (id == null)
            {

            }

            DateTime yil = DateTime.Now;

            mt.movie = db.Movie.Find(id);
            mt.movieType = db.MovieType.Where(x => x.MovieId == id).ToList();
            mt.writerDetail = db.WriterDetail.Where(x => x.MovieId == id).ToList();
            mt.directorDetail = db.DirectorDetail.Where(x => x.MovieId == id).ToList();
            mt.celebriteDetail = db.CelebriteDetail.Where(x => x.MovieId == id).ToList();
            mt.hallDetail = db.HallDetail.Where(x => x.MovieId == id && yil <= x.DateTime).ToList();
            mt.movieFormatDetail = db.MovieFormatDetail.ToList();

            if (mt.movie == null)
            {

            }

            TempData["ID"] = id;
            TempData["Location"] = "İstanbul";
            TempData["Time"] = mt.movie.Time;
            TempData["Name"] = mt.movie.Name;

            return View(mt);
        }

        public ActionResult Details(int id)
        {
            ts.HallDetail = db.HallDetail.Find(id);
            ts.Seat = db.Seat.ToList();
            Session["Ticket"] = "Ticket";
            return View(ts);
        }

        public ActionResult Seats(int id)
        {
            var seat = db.Seat.ToList();
            return View(seat);
        }

        public ActionResult Sales()
        {
            return View();
        }
    }
}