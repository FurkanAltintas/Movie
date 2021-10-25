using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class MovieDirectorWriter
    {
        public Movie movie { get; set; }
        public IEnumerable<MovieType> movieType { get; set; }
        public IEnumerable<WriterDetail> writerDetail { get; set; }
        public IEnumerable<DirectorDetail> directorDetail { get; set; }
        public IEnumerable<CelebriteDetail> celebriteDetail { get; set; }
        public IEnumerable<WatchList> watchList { get; set; }
    }
}