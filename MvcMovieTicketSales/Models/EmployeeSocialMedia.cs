using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieTicketSales.Models
{
    public class EmployeeSocialMedia
    {
        public Employee employee { get; set; }
        public IEnumerable<EmployeeFollow> employeeFollow { get; set; }
        public IEnumerable<EmployeeSkill> employeeSkill { get; set; }
    }
}