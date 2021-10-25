namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        public int? MovieId { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(75)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public DateTime? History { get; set; }

        public bool? Status { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
