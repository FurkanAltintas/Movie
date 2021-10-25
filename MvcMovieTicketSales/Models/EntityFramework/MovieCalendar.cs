namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieCalendar")]
    public partial class MovieCalendar
    {
        public int Id { get; set; }

        public int? MovieId { get; set; }

        public int? MovieHours { get; set; }
    }
}
