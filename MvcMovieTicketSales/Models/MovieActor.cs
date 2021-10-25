using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class MovieActor
    {
        public IEnumerable<Movie> movie { get; set; }
        public Movie Movie { get; set; }
        public Celebrite Celebrite { get; set; }
        public IEnumerable<CelebriteDetail> celebriteDetail { get; set; }
    }
}