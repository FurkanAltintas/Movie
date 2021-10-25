namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Celebrite")]
    public partial class Celebrite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Celebrite()
        {
            CelebriteDetail = new HashSet<CelebriteDetail>();
            CelebriteFollow = new HashSet<CelebriteFollow>();
            CelebriteTask = new HashSet<CelebriteTask>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(150)]
        public string Image { get; set; }

        public bool? Gender { get; set; }

        public int? Age { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(50)]
        public string Hobby { get; set; }

        public string Overview { get; set; }

        public DateTime? History { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CelebriteDetail> CelebriteDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CelebriteFollow> CelebriteFollow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CelebriteTask> CelebriteTask { get; set; }
    }
}
