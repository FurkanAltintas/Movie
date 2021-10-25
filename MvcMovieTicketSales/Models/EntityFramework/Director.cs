namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Director")]
    public partial class Director
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Director()
        {
            DirectorDetail = new HashSet<DirectorDetail>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(150)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Overview { get; set; }

        public DateTime? History { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DirectorDetail> DirectorDetail { get; set; }
    }
}
