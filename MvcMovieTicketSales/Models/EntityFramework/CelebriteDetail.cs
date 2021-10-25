namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CelebriteDetail")]
    public partial class CelebriteDetail
    {
        public int Id { get; set; }

        public int? CelebriteId { get; set; }

        public int? MovieId { get; set; }

        public bool? Status { get; set; }

        public virtual Celebrite Celebrite { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
