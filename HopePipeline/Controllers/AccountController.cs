using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HopePipeline.Models;
using System.Net.Mail;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HopePipeline.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       [Route("login")]
       [HttpPost]

        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null && username.Equals("ccr") && password.Equals("123"))
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("RefList","Referral");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("../Home/Index");
            }
        }

        [Route("logout")]
        [HttpGet]

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }


        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendForgotPassEmail(ForgotAccount account)
        {
              MailMessage mail = new MailMessage();
                          SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                          mail.From = new MailAddress("hopepipeline@gmail.com");
                          string rsemail = account.email;
                          mail.To.Add(rsemail);

                          mail.Subject = "Forgot Password link";
                          DateTime Date = DateTime.Now;
              string mails = "PLaceholder. Email is " + account.email;
                          mail.Body = mails;



                          SmtpServer.Port = 587;
                          SmtpServer.Credentials = new System.Net.NetworkCredential("hopepipeline@gmail.com", "ReferralInfo22");
                          SmtpServer.EnableSsl = true;
                          SmtpServer.Send(mail);

            return RedirectToAction("Index", "Home");
        }


    }
}
