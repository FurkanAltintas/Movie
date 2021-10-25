using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class MovieCategoryType
    {
        public Movie movie { get; set; }
        public IEnumerable<MovieCategory> movieCategory { get; set; }
        public IEnumerable<MovieType> movieType { get; set; }
        public IEnumerable<Movie> Movie { get; set; }
    }
}