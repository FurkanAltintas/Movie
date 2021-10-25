using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class DirectorController : Controller
    {
        MovieMvc db = new MovieMvc();
        // GET: Director
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {

            }

            var key = db.Director.Find(id);

            if (key == null)
            {

            }
            return View(key);
        }
    }
}