namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Update")]
    public partial class Update
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Icon { get; set; }

        [StringLength(100)]
        public string Text { get; set; }

        public DateTime? History { get; set; }
    }
}
