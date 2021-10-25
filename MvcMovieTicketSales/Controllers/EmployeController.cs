using MvcMovieTicketSales.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcMovieTicketSales.Controllers
{
    public class EmployeController : Controller
    {
        public static string to;
        MovieMvc db = new MovieMvc();

        // GET: Employe
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            var key = db.Employee.FirstOrDefault(x => x.Email == employee.Email && x.Password == employee.Password && x.Status == true);

            if (key != null)
            {
                FormsAuthentication.SetAuthCookie(key.Email, false);
                Session["Id"] = key.Id;
                Session["FullName"] = key.Name + " " + key.Surname;
                Session["Profile"] = key.Profile;
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.Error = "Email veya Şifre Hatalı";
                return View();
            }
        }

        public ActionResult PasswordRecovery(string email)
        {
            if (email != null)
            {
                var user = db.Employee.Where(x => x.Email == email && x.Status == true).FirstOrDefault();

                if (user == null)
                {
                    ViewBag.Error = "Sistemde böyle bir email adresi bulunmamaktadır";
                    return View();
                }

                Random r = new Random();
                string harfler = "1ABC2DEF3GHI4JKL5MNO6PRS7TUV8WXY9Z";
                string password = "";
                for (int i = 0; i < 6; i++)
                {
                    password += harfler[r.Next(harfler.Length)];
                }

                TempData["Password"] = password;
                TempData["Id"] = user.Id;

                //var pas = Crypto.Hash(password.Trim(), "MDS").ToLower();
                //user.Password = pas;
                //db.SaveChanges();
                SendForgetMail(user.Name, user.Surname, user.Email, password);
                return View("ForgotPassword");
            }

            return View();
        }

        public static void SendForgetMail(string name, string surname, string mail, string password)
        {
            string mailbody;

            try
            {
                MailMessage mesaj = new MailMessage();
                to = (mail).ToString();
                mailbody = "Merhaba" + name + " " + surname + ",<br>" + "Şifreniz: " + password;
                mesaj.To.Add(mail);
                mesaj.CC.Add("furkanaltintas785@gmail.com");
                mesaj.From = new MailAddress("furkanaltintas785@gmail.com", "Şifre Değiştirme Bildirim");
                mesaj.Body = mailbody;
                mesaj.Subject = "MovieApp | Şifre Değiştirme Talebi";
                mesaj.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("furkanaltintas785@gmail.com", "sefafurkanC#6054");
                smtp.Send(mesaj);
            }
            catch (Exception)
            {

            }
        }

        public ActionResult ForgotPassword(Employee employee, string activation)
        {
            var key = TempData["Password"];
            var id = TempData["Id"];

            var info = db.Employee.Find(id);

            if (employee.Password == employee.RPassword && key == activation)
            {
                info.Password = employee.Password;
                info.RPassword = employee.RPassword;
                db.SaveChanges();
            }

            if (employee.Password != employee.RPassword)
            {
                ViewBag.Error = "Mail bilginiz hatalıdır";
                return View();
            }

            if (key != activation)
            {
                ViewBag.Error = "Aktivasyon kodu hatalı";
                return View();
            }

            return RedirectToAction("Login", "Employe");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Employe");
        }
    }
}