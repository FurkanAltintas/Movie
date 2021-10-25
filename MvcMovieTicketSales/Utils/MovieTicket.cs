using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Utils
{
    public class MovieTicket
    {
        public static string Movie(string kelime)
        {
            if (kelime == "" || kelime == null) { return string.Empty; }

            kelime = kelime.Replace("İ", "I");
            kelime = kelime.Replace("Ü", "U");
            kelime = kelime.Replace("Ö", "O");
            kelime = kelime.Replace(".", ""); return kelime;
        }

    }
}