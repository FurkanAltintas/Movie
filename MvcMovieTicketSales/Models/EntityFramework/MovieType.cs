namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieType")]
    public partial class MovieType
    {
        public int Id { get; set; }

        public int? MovieCategoryId { get; set; }

        public int? MovieId { get; set; }

        public bool? Status { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual MovieCategory MovieCategory { get; set; }
    }
}
