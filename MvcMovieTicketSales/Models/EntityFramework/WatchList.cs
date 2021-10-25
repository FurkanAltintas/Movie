namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WatchList")]
    public partial class WatchList
    {
        public int Id { get; set; }

        public int? MemberId { get; set; }

        public int? MovieId { get; set; }

        public virtual Member Member { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
