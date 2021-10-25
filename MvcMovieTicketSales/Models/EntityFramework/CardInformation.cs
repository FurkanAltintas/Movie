namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CardInformation")]
    public partial class CardInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CardInformation()
        {
            TicketSale = new HashSet<TicketSale>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? MemberId { get; set; }

        public int? ExpiryDateYear { get; set; }

        public int? ExpiryDateMonth { get; set; }

        public int? NameOnTheCard { get; set; }

        public int? CardNumber { get; set; }

        public short? SecurityCode { get; set; }

        public virtual Month Month { get; set; }

        public virtual Year Year { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketSale> TicketSale { get; set; }
    }
}
