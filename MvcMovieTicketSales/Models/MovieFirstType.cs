using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class MovieFirstType
    {
        public Movie movie { get; set; }
        public MovieCategory movieCategory { get; set; }
        public MovieType movieType { get; set; }
        public Celebrite celebrite { get; set; }
        public IEnumerable<CelebriteDetail> celebriteDetail { get; set; }
        public Director director { get; set; }
        public DirectorDetail directorDetail { get; set; }
    }
}