namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seat")]
    public partial class Seat
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string Row { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
