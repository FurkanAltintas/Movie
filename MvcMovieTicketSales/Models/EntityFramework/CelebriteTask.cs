namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CelebriteTask")]
    public partial class CelebriteTask
    {
        public int Id { get; set; }

        public int? CelebriteId { get; set; }

        [StringLength(75)]
        public string Name { get; set; }

        public virtual Celebrite Celebrite { get; set; }
    }
}
