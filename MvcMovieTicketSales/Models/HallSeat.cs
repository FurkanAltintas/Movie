using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class HallSeat
    {
        public Hall hall { get; set; }
        public IEnumerable<Hall> hallList { get; set; }
        public HallDetail hallDetail { get; set; }
        public Movie movie { get; set; }
        public MovieFormat movieFormat { get; set; }
    }
}