namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TicketSale")]
    public partial class TicketSale
    {
        public int Id { get; set; }

        public int? MemberId { get; set; }

        public int? HallDetailId { get; set; }

        public int? CardInformationId { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual CardInformation CardInformation { get; set; }

        public virtual Member Member { get; set; }
    }
}
