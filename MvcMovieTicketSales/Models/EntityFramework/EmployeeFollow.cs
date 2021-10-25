namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeFollow")]
    public partial class EmployeeFollow
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }

        public int? SocialMediaId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Url { get; set; }

        public DateTime? History { get; set; }

        public bool? Status { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual SocialMedia SocialMedia { get; set; }
    }
}
