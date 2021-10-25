using MvcMovieTicketSales.Models;
using MvcMovieTicketSales.Models.EntityFramework;
using MvcMovieTicketSales.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class EmployeeController : BaseController
    {
        MovieMvc db = new MovieMvc();
        EmployeeSocialMedia esm = new EmployeeSocialMedia();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile(int? id)
        {
            if (id == null)
            {
                var key = (int)Session["Id"];
                esm.employee = db.Employee.Where(x => x.Id == key).FirstOrDefault();
                esm.employeeFollow = db.EmployeeFollow.Where(x => x.EmployeeId == key && x.SocialMedia.Status == true).Take(3).ToList();
                esm.employeeSkill = db.EmployeeSkill.Where(x => x.EmployeeId == key && x.Skill.Status == true).Take(4).ToList();
            }
            else
            {
                esm.employee = db.Employee.Where(x => x.Id == id).FirstOrDefault();
                esm.employeeFollow = db.EmployeeFollow.Where(x => x.EmployeeId == id).Take(3).ToList();
                esm.employeeSkill = db.EmployeeSkill.Where(x => x.EmployeeId == id).Take(4).ToList();
            }
            //var information = db.Member.FirstOrDefault(x => x.Id == key);
            return View(esm);
        }

        [HttpPost]
        public ActionResult ProfileUpdate(Employee employee)
        {
            var key = (int)Session["Id"];
            var information = db.Employee.Where(x => x.Id == key).FirstOrDefault();


            if (Request.Files.Count > 0 && employee.Password == employee.RPassword)
            {
                var file = Request.Files[0];

                string dosyaAdi = Path.GetFileName(file.FileName);
                string uzanti = Path.GetExtension(file.FileName);
                string adres = "~/Images/Employe/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(adres));
                information.Profile = "/Images/Employe/" + dosyaAdi + uzanti;
                information.Name = employee.Name;
                information.Surname = employee.Surname;
                information.Email = employee.Email;
                information.Phone = employee.Phone;
                information.Password = employee.Password;
                information.RPassword = information.Password;
                information.Information = employee.Information;
            }
            else
            {
                return RedirectToAction("Profile", "Employee");
            }

            db.SaveChanges();
            return RedirectToAction("Profile", "Employee");
        }
    }
}