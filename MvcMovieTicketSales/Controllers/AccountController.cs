using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CvMvc.Controllers
{
    public class AccountController : Controller
    {
        MovieMvc db = new MovieMvc();
        // GET: Account

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Member member)
        {
            var key = db.Member.Where(x => x.Email == member.Email && x.Password == member.Password && x.Status == true).FirstOrDefault();

            if (key != null)
            {
                FormsAuthentication.SetAuthCookie(key.Email, false);
                Session["MId"] = key.Id;
                Session["MFullName"] = key.Name + " " + key.SurName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Email veya Şifre Hatalı";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member member)
        {
            if (member.Password == member.RPassword)
            {
                member.History = DateTime.Now;
                member.Status = true;
                db.Member.Add(member);
                db.SaveChanges();
                Session["FullName"] = member.Name + " " + member.SurName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Şifre aynı olmalıdır";
                return View();
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}