namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DirectorDetail")]
    public partial class DirectorDetail
    {
        public int Id { get; set; }

        public int? DirectorId { get; set; }

        public int? MovieId { get; set; }

        public bool? Status { get; set; }

        public virtual Director Director { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
