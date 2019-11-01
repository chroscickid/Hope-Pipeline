using System;
using System.Collections.Generic;
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
using System.Text;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.Dynamic;

namespace HopePipeline.Controllers
{
    public class bController : Controller
    {
        private AppDbContext db;


        private IHostingEnvironment hostingEnvironment;


        public bController(AppDbContext _db, IHostingEnvironment _hostingEnvironment)
        {
            db = _db;


            hostingEnvironment = _hostingEnvironment;
        }





        public IActionResult IndexA()
        {
            return View();
        }
        public ViewResult formReferralBLD()
        {
            {



                ViewBag.Message = "Your contact page.";
                int here = 0;


                int maxorder = 0;
                maxorder = db.referralBrandi.Count();
                if (maxorder == 0)
                {
                    here = 1;

                }
                else
                {
                    here = maxorder + 1;
                }
                ViewBag.PKvalue = here;

                int herefiles = 0;
                int maxorderfiles = 0;

                maxorderfiles = db.filesReferralBrandi.Count();
                if (maxorderfiles == 0)
                {
                    herefiles = 1;

                }
                else { herefiles = (db.filesReferralBrandi.OrderBy(p => p.idPK).Max(p => p.idPK) + 1); }
                ViewBag.file = herefiles;
                ViewBag.ms = DateTime.Today;


                ViewBag.Status = "Pending";



                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult formReferralBLD(string Mother, string Father, string Guardian, string Familymember, string FosterParent, string VariableFM, string Failed,
            string Suspended, string Alt, string Plan, string Notenrolled, string Hxbaker, string Meeting, string meetingtime,
            string School, string Reach, string primaryKey, string status, string dateInput, IFormFile[] file,
               referralBrandi referral)



        {
            if (ModelState.IsValid)
            {

                referral.pK = Convert.ToInt32(primaryKey);
                referral.status = status;


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


                db.referralBrandi.Add(referral);


                string sessionName = referral.fName.ToString();
                string sessionLast = referral.lName.ToString();
                string sessionID = referral.pK.ToString();

                db.SaveChanges();
                file.ToList();
                int cat = 0;
                int number = 0;
                int herefiles = 0;
                int maxorderfiles = 0;

                maxorderfiles = db.filesReferralBrandi.Count();
                if (maxorderfiles == 0)
                {
                    herefiles = 1;

                }
                else { herefiles = (db.filesReferralBrandi.OrderBy(p => p.idPK).Max(p => p.idPK) + 1); }

                foreach (var files in file)
                {

                    if (files != null)

                    {
                        string unqiueFileName = null;

                        string webRootPath = hostingEnvironment.ContentRootPath;

                        string uploadsFolder = Path.Combine(webRootPath, "wwwroot\\images");

                        unqiueFileName = Guid.NewGuid().ToString() + "_" + files.FileName;

                        string filePath = Path.Combine(uploadsFolder, unqiueFileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            files.CopyTo(fs);
                            fs.Flush();
                        }




                        int numbe = 0;



                        if (cat < 1)
                        {
                            cat++;
                            filesReferralBrandi referralfile = new filesReferralBrandi();
                            referralfile.idPK = herefiles;
                            referralfile.pK = Convert.ToInt32(sessionID);
                            referralfile.file = files.FileName;
                            referralfile.fileCode = filePath;
                            referralfile.fileNameY = "/images/" + unqiueFileName;

                            db.filesReferralBrandi.Add(referralfile);

                            db.SaveChanges();

                        }
                        else
                        {
                            cat++;
                            number++;
                            herefiles++;
                            filesReferralBrandi referralfile = new filesReferralBrandi();

                            numbe = referralfile.idPK + herefiles;
                            referralfile.idPK = numbe;
                            referralfile.pK = Convert.ToInt32(sessionID);
                            referralfile.file = files.FileName;
                            referralfile.fileCode = filePath;
                            referralfile.fileNameY = "/images/" + unqiueFileName;

                            db.filesReferralBrandi.Add(referralfile);

                            db.SaveChanges();

                        }


                    }
                }

                CreateTestMessage3(referral);
                return RedirectToAction("ConfirmationRe1", new { referral.pK });
            }
            return View(referral);
        }


        public static void CreateTestMessage3(referralBrandi referral)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("hopepipeline@gmail.com");
            mail.To.Add("hopepipeline@gmail.com");
            mail.Subject = "New Referral!";
            DateTime Date = DateTime.Now;
            string mails = "A referral form has just been entered as of " + Date + " for " + referral.fName + " " + referral.lName;
            mail.Body = mails;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("hopepipeline@gmail.com", "ReferralInfo22");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            return;
        }


        public IActionResult ConfirmationReBLD(string emailaddress, int Id)
        {


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("hopepipeline@gmail.com");
            string rsemail = emailaddress;
            mail.To.Add(rsemail);
            referralBrandi referral1 = db.referralBrandi.Find(Id);
            string FirstName = referral1.fName.ToString();
            string LastName = referral1.lName.ToString();
            mail.Subject = "Confirmation on Referral for " + FirstName;
            DateTime Date = DateTime.Now;

            string mails = "This is Confirmation for the referral form " + "entered as of " + Date + " for " + FirstName + " " + LastName;
            mail.Body = mails;



            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("hopepipeline@gmail.com", "ReferralInfo22");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            return RedirectToAction("Index", "Home");
        }

        public ViewResult ConfirmationRe1(referralBrandi referral)
        {
            int Id = referral.pK;
            referralBrandi referral1 = db.referralBrandi.Find(Id);

            string FirstName = referral1.fName.ToString();
            string LastName = referral1.lName.ToString();
            string Date = DateTime.Now.ToString();

            ViewData["message"] = "Your Referral for " + FirstName + " " + LastName + " has been submitted as of " + Date;
            ViewBag.two = "We look forward to helping " + FirstName + " " + LastName + ",";
            ViewBag.number = Id;
            return View("ConfirmationReBLD", new { Id });
        }


        public ActionResult listReferralBLD()
        {
            ViewData["Message"] = "Your application description page.";



            return View(db.referralBrandi.ToList());


        }



        public ActionResult contactInfoBLD(int pK)
        {
            ViewData["Message"] = "Your application description page.";



            referralBrandi referral = db.referralBrandi.Find(pK);




            return View(referral);


        }

        public ActionResult detailReferralBLD(int pK)
        {
            List<object> myModel = new List<object>();
            ViewData["Message"] = "Detail of Referral information for clients.";

            var list = from r in db.referralBrandi
                       where (r.pK == pK)
                       select r;
            var list2 = from r in db.filesReferralBrandi
                        where (r.pK == pK)
                        select r;


            myModel.Add(list.ToList());
            myModel.Add(list2.ToList());

            return View(myModel);
        }
        public ActionResult listTrackingBLD()
        {
            ViewData["Message"] = "Manage Tracking Information.";




            return View(db.trackingReferral.ToList());
        }
        public ActionResult detailTrackingBLD(int pK)
        {
            List<object> myModel = new List<object>();
            ViewData["Message"] = "Detail of Referral information for clients.";

            var list = from r in db.referralBrandi
                       where (r.pK == pK)
                       select r;
            var list2 = from r in db.trackingReferral
                        where (r.pK == pK)
                        select r;



            myModel.Add(list.ToList());
            myModel.Add(list2.ToList());

            return View(myModel);
        }

    }
}