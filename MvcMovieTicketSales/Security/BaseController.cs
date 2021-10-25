using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Utils
{
    public class BaseController : Controller
    {
        public MovieMvc db = new MovieMvc();

        public string Id { get; set; }

        public string FullName { get; set; }
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Id"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/");
            }
            else
            {
                Id = Session["Id"].ToString();
                FullName = Session["FullName"].ToString();

            }
            base.OnActionExecuting(filterContext);
        }
    }
}