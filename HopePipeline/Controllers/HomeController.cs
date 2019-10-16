using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;


using System.Web;

using System.Data;

using System.Net;
using System.Net.Mail;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace HopePipeline.Controllers
{
    public class HomeController : Controller


    {
        private ApplicationDbContext db;
      
        public HomeController(ApplicationDbContext _db)
        { db = _db; }


          //private HopePipelineName db = new dbEntities1();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ViewResult Referral()
        {
            {
                



            ViewBag.Message = "Your contact page.";
            int here =0;


            int maxorder = 0;
            maxorder = db.Referrals.Count();
           if( maxorder == 0)
            {
                 here = 1;
              
            }
            else {// here = (db.Referrals.OrderBy(p => p.Id).Max(p => p.Id) +1);
                here = maxorder+1;
            }
            ViewBag.PKvalue = here;

            int herefiles = 0;
            int maxorderfiles = 0;
            
            maxorderfiles = db.FilesReferrals.Count();
            if (maxorderfiles == 0)
            {
                herefiles = 1;

            }
            else { herefiles = (db.FilesReferrals.OrderBy(p => p.idPK).Max(p => p.idPK) + 1); }
            ViewBag.file = herefiles;
            ViewBag.ms = DateTime.Today;
            
           
            ViewBag.Status = "Pending";


           
            return View();
        }
        }
       
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
     public ActionResult Referral(string Mother, string Father, string Guardian, string Familymember, string FosterParent, string VariableFM, string Failed,
            string Suspended, string Alt, string Plan, string Notenrolled, string Hxbaker, string Meeting, string meetingtime,
            string School, string Reach, IFormFile[] file,
               Referral referral)



        {
            if (ModelState.IsValid)
            {

                //First Checkbox
                //answer equals checkboxes of guardians for client
                string answer = null;
                if (Mother != null)
                { answer = Mother + "," + " "; }
                if (Father != null)
                { answer = answer + Father + "," + " "; }
                if (Guardian != null)
                { answer = answer + Guardian + "," + " "; }
                if (Familymember != null)
                { answer = answer + Familymember + "," + " "; }
                if (FosterParent != null)
                { answer = answer + FosterParent + "," + " "; }
                if (VariableFM != null)
                { answer = answer + VariableFM + "," + " "; }
                referral.guardianRelationship = answer;

                //Second Checkbox
                string answer1 = null;
                if (Failed != null)
                { answer1 = Failed + "," + " "; }
                if (Suspended != null)
                { answer1 = answer1 + Suspended + "," + " "; }
                if (Alt != null)
                { answer1 = answer1 + Alt + "," + " "; }
                if (Plan != null)
                { answer1 = answer1 + Plan + "," + " "; }
                if (Notenrolled != null)
                { answer1 = answer1 + Notenrolled + "," + " "; }
                if (Hxbaker != null)
                { answer1 = answer1 + Hxbaker + "," + " "; }
                referral.issues = answer1;

                referral.youthInSchool = School;

                referral.meeting = Meeting;

                referral.time = meetingtime;

                referral.communication = Reach;

                db.Configuration.ValidateOnSaveEnabled = false;
                db.Referrals.Add(referral);

                
             string sessionName = referral.fName.ToString();
              string sessionLast = referral.lName.ToString();
               string sessionID = referral.pK.ToString();

                db.SaveChanges();
                file.ToList();
                int cat = 0;
                int number = 0;
                int herefiles = 0;
                int maxorderfiles = 0;

                maxorderfiles = db.FilesReferrals.Count();
                if (maxorderfiles == 0)
                {
                    herefiles = 1;

                }
                else { herefiles = (db.FilesReferrals.OrderBy(p => p.idPK).Max(p => p.idPK) + 1); }

                foreach (var files in file)
                {

                    if (files != null)

                    {
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                        files.CopyToAsync(path);

                        int numbe = 0;



                        if (cat < 1)
                        {
                            cat++;
                            FilesReferrals referralfile = new FilesReferrals();
                            referralfile.idPK = herefiles;
                            referralfile.pK = Convert.ToInt32(sessionID);
                            referralfile.file = files.FileName;
                            referralfile.fileCode = "/Files/" + fileName;
                            db.Configuration.ValidateOnSaveEnabled = false;
                            db.FilesReferrals.Add(referralfile);

                            db.SaveChanges();

                        }
                        else
                        {
                            cat++;
                            number++;
                            herefiles++;
                            FilesReferrals referralfile = new FilesReferrals();

                            numbe = referralfile.idPK + herefiles;
                            referralfile.idPK = numbe;
                            referralfile.pK= Convert.ToInt32(sessionID);
                            referralfile.file = files.FileName;
                            referralfile.fileCode = "/Files/" + fileName;
                            db.Configuration.ValidateOnSaveEnabled = false;
                            db.FilesReferrals.Add(referralfile);

                            db.SaveChanges();

                        }
                        //still in same file after first number++ after does not belong to a separate file
                        //goes from 1 to 3
                        //

                    }
                }

                CreateTestMessage3(referral);
                return RedirectToAction("ConfirmationRe1", new {referral.pK});
            }
            return View(referral);
        }

          public static void CreateTestMessage3(Referral referral)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("hopepipeline@gmail.com");
            mail.To.Add("hopepipeline@gmail.com");
            mail.Subject = "New Referral!";
            DateTime Date = DateTime.Now;
            string mails = "A referral form has just been entered as of " + Date + " for " + referral.fName +" "+ referral.lName;
            mail.Body = mails;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("hopepipeline@gmail.com", "ReferralInfo22");
            SmtpServer.EnableSsl = true;
            //ReferralInfo22
            //jan101999//not say
            SmtpServer.Send(mail);
            return;
        }

        public IActionResult ConfirmationRe(string emailaddress, int Id)
        {
            // method should be pulled upon referral submission
            //not connected yet

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("hopepipeline@gmail.com");
            string rsemail = emailaddress;
            mail.To.Add(rsemail);
            Referral referral1 = db.Referrals.Find(Id);
            string FirstName = referral1.fName.ToString();
            string LastName = referral1.lName.ToString();
            mail.Subject = "Confirmation on Referral for " + FirstName;
            DateTime Date = DateTime.Now;
           
            string mails = "This is Confirmation for the referral form " + "entered as of " + Date + " for " + FirstName + " " + LastName;
            mail.Body = mails;



            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("hopepipeline@gmail.com", "ReferralInfo22");
            SmtpServer.EnableSsl = true;
            //ReferralInfo22
            //jan101999//not say
            SmtpServer.Send(mail);
            return RedirectToAction("Index");
        }

        public ViewResult ConfirmationRe1(Referral referral)
        {
            int Id = referral.pK;
            Referral referral1 = db.Referrals.Find(Id);
        
            string FirstName = referral1.fName.ToString();
            string LastName = referral1.lName.ToString();
            string Date = DateTime.Now.ToString();
     
            ViewData["message"] = "Your Referral for "+  FirstName +" " + LastName + " has been submitted as of " + Date;
            ViewBag.two = "We look forward to helping " + FirstName + " " + LastName + ",";
            ViewBag.number = Id;
            return View("ConfirmationRe" ,new {Id}); }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
     }   }
    }

