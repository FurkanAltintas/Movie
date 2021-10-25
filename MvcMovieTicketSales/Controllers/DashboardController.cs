using MvcMovieTicketSales.Models.EntityFramework;
using MvcMovieTicketSales.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class DashboardController : BaseController
    {
        MovieMvc db = new MovieMvc();
        // GET: Dashboard
        public ActionResult Index()
        {
            var employe = db.Employee.Where(x => x.Status == true).ToList();

            ViewBag.Movies = db.Movie.Count();
            ViewBag.Member = db.Member.Where(x => x.Status == true).Count();
            ViewBag.Employe = db.Employee.Where(x => x.Status == true).Count();
            return View(employe);
        }
    }
}