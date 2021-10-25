namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieFormatDetail")]
    public partial class MovieFormatDetail
    {
        public int Id { get; set; }

        public int? HallDetailId { get; set; }

        public int? MovieFormatId { get; set; }

        public virtual HallDetail HallDetail { get; set; }

        public virtual MovieFormat MovieFormat { get; set; }
    }
}
