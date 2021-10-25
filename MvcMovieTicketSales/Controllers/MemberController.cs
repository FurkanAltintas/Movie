using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovieTicketSales.Controllers
{
    public class MemberController : Controller
    {
        MovieMvc db = new MovieMvc();
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Info()
        {
            var key = (int)Session["MId"];
            var information = db.Member.FirstOrDefault(x => x.Id == key);
            return View(information);
        }

        [HttpPost]
        public ActionResult PersonalInformation(Member member)
        {
            var key = (int)Session["MId"];
            var information = db.Member.FirstOrDefault(x => x.Id == key);

            information.Name = member.Name;
            information.SurName = member.SurName;
            information.Phone = member.Phone;
            db.SaveChanges();
            return RedirectToAction("Info", "Member");
        }

        [HttpPost]
        public ActionResult PasswordTransactions(Member member, FormCollection password)
        {
            string oldKey = password["OldPassword"];

            var key = (int)Session["MId"];
            var information = db.Member.FirstOrDefault(x => x.Id == key);

            if (information.Password == oldKey)
            {
                if (member.Password == member.RPassword)
                {
                    information.Password = member.Password;
                    information.RPassword = member.RPassword;
                    db.SaveChanges();
                    return RedirectToAction("Info", "Member");
                }
                else
                {
                    ViewBag.Password = "Şifre aynı olmalıdır";
                    return View("Info");
                }
            }
            else
            {
                ViewBag.Password = "Girdiğiniz şifre hatalıdır";
                return View("Info");
            }
        }

        public ActionResult WatchList()
        {
            if (Session.Contents["MId"] == null)
            {
                return RedirectToAction("Index","Home");
            }

            var key = (int)Session["MId"];
            var information = db.Member.FirstOrDefault(x => x.Id == key);

            var watchList = db.WatchList.Where(x => x.MemberId == information.Id).ToList();

            return View(watchList);
        }
    }
}