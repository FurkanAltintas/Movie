using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class TicketSeat
    {
        public HallDetail HallDetail { get; set; }
        public IEnumerable<Seat> Seat { get; set; }
    }
}