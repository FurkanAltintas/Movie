namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MovieHours
    {
        public int Id { get; set; }

        public int? MovieDateId { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        public virtual MovieDate MovieDate { get; set; }
    }
}
