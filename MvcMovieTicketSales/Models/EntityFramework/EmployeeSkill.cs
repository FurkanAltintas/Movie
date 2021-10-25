namespace MvcMovieTicketSales.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeSkill")]
    public partial class EmployeeSkill
    {
        public int Id { get; set; }

        public int? SkillId { get; set; }

        public int? EmployeeId { get; set; }

        public short? Degree { get; set; }

        public DateTime? History { get; set; }

        public bool? Status { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
