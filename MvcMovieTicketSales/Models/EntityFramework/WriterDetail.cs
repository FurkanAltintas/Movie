namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WriterDetail")]
    public partial class WriterDetail
    {
        public int Id { get; set; }

        public int? MovieId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
