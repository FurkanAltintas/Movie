namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CelebriteFollow")]
    public partial class CelebriteFollow
    {
        public int Id { get; set; }

        public int? CelebriteId { get; set; }

        public int? SocialMediaId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Url { get; set; }

        public virtual Celebrite Celebrite { get; set; }

        public virtual SocialMedia SocialMedia { get; set; }
    }
}
