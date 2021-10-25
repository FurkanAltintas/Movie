using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class SkillList
    {
       public Skill skill { get; set; }
       public IEnumerable<Skill> skillList { get; set; }
    }
}