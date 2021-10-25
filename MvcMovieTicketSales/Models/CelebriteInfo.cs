using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class CelebriteInfo
    {
        public Celebrite celebrite { get; set; }
        public IEnumerable<Celebrite> celebriteList { get; set; }
        public IEnumerable<CelebriteDetail> celebriteDetail { get; set; }
        public IEnumerable<CelebriteFollow> celebriteFollow { get; set; }
    }
}