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

namespace HopePipeline.Controllers
{
    public class bController : Controller
    {
        private AppDbContext db;


        private IHostingEnvironment hostingEnvironment;


        public bController(AppDbContext _db, IHostingEnvironment _hostingEnvironment)
        { db = _db;


            hostingEnvironment = _hostingEnvironment; }



        //Referral
      

        public ViewResult referralBrandi()
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
                else {// here = (db.Referrals.OrderBy(p => p.Id).Max(p => p.Id) +1);
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

        // ReferralString
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult referralBrandi(string Mother, string Father, string Guardian, string Familymember, string FosterParent, string VariableFM, string Failed,
            string Suspended, string Alt, string Plan, string Notenrolled, string Hxbaker, string Meeting, string meetingtime,
            string School, string Reach, string primaryKey, string status, string dateInput, IFormFile[] file,
               referralBrandi referral)

        // <input type = "hidden"  name="foreignKeyValue" value="ViewBag.PKvalue">
        //<input type = "hidden"  name="primaryKeyValue" value="ViewBag.file">

        {
            if (ModelState.IsValid)
            {

                referral.pK = Convert.ToInt32(primaryKey);
                referral.status = status;

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

                // db.Configuration.ValidateOnSaveEnabled = false;
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
                        //
                        string webRootPath = hostingEnvironment.ContentRootPath;
                        //path
                        string uploadsFolder = Path.Combine(webRootPath, "wwwroot\\images");
                        //Name
                        unqiueFileName = Guid.NewGuid().ToString() + "_" + files.FileName;
                        //combine
                        string filePath = Path.Combine(uploadsFolder, unqiueFileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        { files.CopyTo(fs);
                            fs.Flush();
                        }
                        
                        
                        //files.CopyTo(new FileStream(filePath, FileMode.Create));

                        /*var webRoot = db.filesReferralBrandi;
                        var fileName = Path.GetFileName(files.FileName);
                        var path = System.IO.Path.Combine(webRoot.ToString(), fileName);
                        // convert string to stream
                        byte[] byteArray = Encoding.UTF8.GetBytes(path);
                        //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
                        MemoryStream stream = new MemoryStream(byteArray);
                        files.CopyToAsync(stream);*/

                        // fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(files.FileName);
                        //using (var fileStream = new FileStream(Path.Combine(@"\FIles\", fileName), FileMode.Create)) ;

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
                            // referralfile.fileCode = "/Files/" + fileName;
                            // db.Configuration.ValidateOnSaveEnabled = false;
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
                            // referralfile.fileCode = "/Files/" + fileName;
                            //db.Configuration.ValidateOnSaveEnabled = false;
                            db.filesReferralBrandi.Add(referralfile);

                            db.SaveChanges();

                        }
                        //still in same file after first number++ after does not belong to a separate file
                        //goes from 1 to 3
                        //

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
            //ReferralInfo22
            //jan101999//not say
            SmtpServer.Send(mail);
            return;
        }

        //ConfirmationRe
        public IActionResult ConfirmationRe(string emailaddress, int Id)
        {
            // method should be pulled upon referral submission
            //not connected yet

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
            //ReferralInfo22
            //jan101999//not say
            SmtpServer.Send(mail);
            return RedirectToAction("Index", "Home");
        }
        //ConfirmationRe1
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
            return View("ConfirmationRe", new { Id }); }


        public ActionResult viewBrandiR()
        {
            ViewData["Message"] = "Your application description page.";


            //  var referrals = from d in db.Referrals
            //              select d.First_Name;

            return View(db.referralBrandi.ToList());


        }



        public ActionResult contactInfoBrandi(int pK)
        {
            ViewData["Message"] = "Your application description page.";

            // if (String.IsNullOrEmpty(pK.ToString()))
            //  {
            //     return View("viewBrandiR");
            //   }
            //
          
            referralBrandi referral = db.referralBrandi.Find(pK);
         
            //if (referral == null)
            //{
            //     return View("viewBrandiR");
            //  }


            return View(referral);


        }

        public ActionResult detailBrandi(int pK)
        {
            List<object> myModel = new List<object>();
            ViewData["Message"] = "Your application description page.";
            // if (String.IsNullOrEmpty(pK.ToString())) {
            //     return View("viewBrandiR");  }
            //
           // referralBrandi referral = db.referralBrandi.Find(pK);
            var list =from r in db.referralBrandi
                        where(r.pK ==pK)
                        select r;
              var list2 = from r in db.filesReferralBrandi
                        where(r.pK ==pK)
                        select r;

            //if (referral == null)
            //{
            //     return View("viewBrandiR");
            //  } 
            myModel.Add(list.ToList());
            myModel.Add(list2.ToList());

            return View(myModel);
        }


    }
    }