using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class PersonnelTitle
    {
        public Employee employee { get; set; }
        public Authority authority { get; set; }
    }
}