using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class Social
    {
        public SocialMedia socialMedia { get; set; }
        public IEnumerable<SocialMedia> socialMediaList { get; set; }
    }
}