using MvcMovieTicketSales.Models;
using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class SkillController : Controller
    {
        MovieMvc db = new MovieMvc();
        SkillList sl = new SkillList();
        // GET: Skill
        public ActionResult Index()
        {
            sl.skillList = db.Skill.ToList();
            return View(sl);
        }

        [HttpPost]
        public ActionResult Add(Skill skill)
        {
            skill.History = DateTime.Now;
            skill.Status = true;
            db.Skill.Add(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var skill = db.EmployeeSkill.Where(x => x.SkillId == id).ToList();

            return View(skill);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var skill = db.Skill.Find(id);
            return View(skill);
        }

        [HttpPost]
        public ActionResult Update(int id, Skill skill)
        {
            var key = db.Skill.Find(id);
            key.Name = skill.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Passive(int id)
        {
            var key = db.Skill.Find(id);
            key.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            var key = db.Skill.Find(id);
            key.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployePassive(int id)
        {
            var key = db.EmployeeSkill.Find(id);
            key.Status = false;
            db.SaveChanges();
            return RedirectToAction("Detail", new { id = id });
        }

        public ActionResult EmployeActive(int id)
        {
            var key = db.EmployeeSkill.Find(id);
            key.Status = true;
            db.SaveChanges();
            return RedirectToAction("Detail", new { id = id });
        }
    }
}