using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Utils
{
    public class YoutubeEmbed
    {
        public static string Embed(string kelime)
        {
            if (kelime == "" || kelime == null) { return string.Empty; }

            kelime = kelime.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/");
            return kelime;
        }

    }
}