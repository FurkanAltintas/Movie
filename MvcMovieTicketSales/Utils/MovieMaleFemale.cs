using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Utils
{
    public class MovieMaleFemale
    {
        public static string MaleFemale(string kelime)
        {
            if (kelime == "" || kelime == null) { return string.Empty; }

            kelime = kelime.Replace("True", "Erkek");
            kelime = kelime.Replace("False", "Kadın");
            return kelime;
        }

    }
}