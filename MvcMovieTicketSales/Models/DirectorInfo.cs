using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMovieTicketSales.Models.EntityFramework;

namespace MvcMovieTicketSales.Models
{
    public class DirectorInfo
    {
        public Director director { get; set; }
        public Movie movie { get; set; }
        public IEnumerable<DirectorDetail> directorDetail { get; set; }
    }
}