using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class Dashboard
    {
        public IEnumerable<Movie> movie { get; set; }
    }
}