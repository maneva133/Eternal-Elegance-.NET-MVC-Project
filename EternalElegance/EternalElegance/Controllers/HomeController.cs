using EternalElegance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EternalElegance.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Gallery()
        {

            return View();
        }

        public ActionResult Team()
        {

            return View();
        }

        public ActionResult Products()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(string Name, string Email, string Message)
        {
            try
            {
                var mail = new MailMessage();
                mail.To.Add("majaman956@gmail.com"); 
                mail.Subject = "New Contact Form Message";
                mail.Body = $"Name: {Name}\nEmail: {Email}\nMessage: {Message}";
                mail.IsBodyHtml = false;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("majaman956@gmail.com", "zvqp wfvt tbjs ppvm");
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                }

                return RedirectToAction("ThankYou");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View("Index");
            }
        }
        
        public ActionResult ThankYou()
        {
            return View();
        }

    }
}