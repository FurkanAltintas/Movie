namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HallDetail")]
    public partial class HallDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HallDetail()
        {
            MovieFormatDetail = new HashSet<MovieFormatDetail>();
        }

        public int Id { get; set; }

        public int? HallId { get; set; }

        public int? MovieId { get; set; }

        public int? MovieFormatId { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(20)]
        public string Date { get; set; }

        [StringLength(20)]
        public string Time { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual Hall Hall { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual MovieFormat MovieFormat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieFormatDetail> MovieFormatDetail { get; set; }
    }
}
