using MvcMovieTicketSales.Models.EntityFramework;
using MvcMovieTicketSales.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class MembersController : BaseController
    {
        MovieMvc db = new MovieMvc();
        // GET: Members
        public ActionResult Index()
        {
            var member = db.Member.ToList();
            return View(member);
        }
    }
}