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
    [Authorize(Roles = "Yönetici")]
    public class EmployeesController : BaseController
    {
        MovieMvc db = new MovieMvc();
        EmployeeSocialMedia esm = new EmployeeSocialMedia();
        // GET: Employees
        public ActionResult Index()
        {
            var employe = db.Employee.ToList();
            return View(employe);
        }

        //public ActionResult Detail(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("Index", "PageNotFound");
        //    }
        //    esm.employee = db.Employee.Where(x => x.Id == id).FirstOrDefault();
        //    esm.employeeFollow = db.EmployeeFollow.Where(x => x.EmployeeId == id).Take(3).ToList();

        //    if (esm.employee == null)
        //    {
        //        return RedirectToAction("Index", "PageNotFound");
        //    }
        //    return View(esm);
        //}

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Authority = new SelectList(db.Authority, "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee, Authority authority)
        {
            if (Request.Files.Count > 0)
            {
                if (employee.Password == employee.RPassword)
                {
                    var file = Request.Files[0];

                    string dosyaAdi = Path.GetFileName(file.FileName);
                    string uzanti = Path.GetExtension(file.FileName);
                    string adres = "~/Images/Employe/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(adres));
                    employee.Profile = "/Images/Employe/" + dosyaAdi + uzanti;
                    employee.AuthorityId = authority.Id;
                    employee.History = DateTime.Now;
                    employee.Status = true;
                    db.Employee.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ViewBag.Error = "Parola bilgileri eşleşmiyor";
                    ViewBag.Authority = new SelectList(db.Authority, "Id", "Name");
                    return View();
                }

            }
            else
            {
                ViewBag.Error = "Eksik bilgi girişi yaptınız";
                ViewBag.Authority = new SelectList(db.Authority, "Id", "Name");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            ViewBag.Authority = new SelectList(db.Authority, "Id", "Name");
            var employe = db.Employee.Find(id);

            if (employe == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }
            return View(employe);
        }

        [HttpPost]
        public ActionResult Update(int id, Employee employee)
        {
            var key = db.Employee.Find(id);

            if (Request.Files.Count > 0 && employee.Password == employee.RPassword)
            {
                if (employee.Password == null || employee.RPassword == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var file = Request.Files[0];

                    string dosyaAdi = Path.GetFileName(file.FileName);
                    string uzanti = Path.GetExtension(file.FileName);
                    string adres = "~/Images/Employe/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(adres));
                    key.Profile = "/Images/Employe/" + dosyaAdi + uzanti;
                    key.Name = employee.Name;
                    key.Surname = employee.Surname;
                    key.Phone = employee.Phone;
                    key.Address = employee.Address;
                    key.Information = employee.Information;
                    key.Email = employee.Email;
                    key.Password = employee.Password;
                    key.RPassword = key.Password;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Update", new { id = id });
            }
        }

        public ActionResult Active(int id)
        {
            var key = db.Employee.Find(id);
            key.Status = false;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            var key = db.Employee.Find(id);
            key.Status = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SocialMedia(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var employee = db.Employee.Find(id);

            ViewBag.SocialMedia = new SelectList(db.SocialMedia, "Id", "Name");

            if (employee == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View();
        }

        [HttpPost]
        public ActionResult SocialMedia(int id, EmployeeFollow employeeFollow)
        {
            if (employeeFollow.SocialMediaId > 0)
            {
                employeeFollow.EmployeeId = id;
                db.EmployeeFollow.Add(employeeFollow);
                db.SaveChanges();
            }
            return RedirectToAction("SocialMedia", "Employees", new { id = id });
        }

        public ActionResult SocialMediaUpdate(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var social = db.EmployeeFollow.Find(id);

            ViewBag.SocialMedia = new SelectList(db.SocialMedia.OrderBy(x => x.Name), "Id", "Name");

            var socialMedia = db.EmployeeFollow.Where(x => x.SocialMediaId == id).FirstOrDefault();

            return View(socialMedia);
        }

        public ActionResult SocialMediaUpdate(int id, EmployeeFollow employeeFollow, SocialMedia socialMedia)
        {
            var key = db.EmployeeFollow.Find(id);
            key.SocialMediaId = socialMedia.Id;
            key.Name = employeeFollow.Name;
            key.Url = employeeFollow.Url;
            db.SaveChanges();
            return RedirectToAction("SocialMedia");

        }

        public ActionResult SocialMediaDelete(int id)
        {
            var social = db.EmployeeFollow.Find(id);
            social.Status = false;
            db.SaveChanges();
            return RedirectToAction("SocialMedia");
        }

        public ActionResult SocialMediaList(int id)
        {
            var employe = db.Employee.Find(id);
            ViewBag.Employe = employe.Name + " " + employe.Surname;

            var social = db.EmployeeFollow.Where(x => x.EmployeeId == id && x.SocialMedia.Status == true).ToList();

            return View(social);
        }

        [HttpGet]
        public ActionResult Skill(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            var employee = db.Employee.Find(id);

            ViewBag.Skill = new SelectList(db.Skill.OrderBy(x => x.Name), "Id", "Name");

            if (employee == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Skill(int id, EmployeeSkill employeeSkill)
        {
            if (employeeSkill.SkillId > 0)
            {
                employeeSkill.EmployeeId = id;
                employeeSkill.History = DateTime.Now;
                employeeSkill.Status = true;
                db.EmployeeSkill.Add(employeeSkill);
                db.SaveChanges();
            }

            return RedirectToAction("Skill", "Employees", new { id = id });
        }

        public ActionResult SkillList(int id)
        {
            var employe = db.Employee.Find(id);
            ViewBag.Employe = employe.Name + " " + employe.Surname;

            var skill = db.EmployeeSkill.Where(x => x.EmployeeId == id).ToList();
            return View(skill);
        }
    }
}