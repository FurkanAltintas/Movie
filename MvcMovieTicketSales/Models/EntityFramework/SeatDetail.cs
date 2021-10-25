namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SeatDetail")]
    public partial class SeatDetail
    {
        public int Id { get; set; }
    }
}
