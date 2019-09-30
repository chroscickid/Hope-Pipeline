using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;

namespace HopePipeline.Controllers
{
    public class HomeController : Controller
    {
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

        public IActionResult Referral()
        {
            int here = 0;


            int maxorder = 0;
            maxorder = db.Referrals.Count();
            if (maxorder == 0)
            {
                here = 1;

            }
            else { here = (db.Referrals.OrderBy(p => p.Id).Max(p => p.Id) + 1); }


            ViewBag.ms = DateTime.Today;
            ViewBag.PKvalue = here;

            ViewBag.Status = "Pending";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(string Mother, string Father, string Guardian, string Familymember, string FosterParent, string VariableFM, string Failed,
             string Suspended, string Alt, string Plan, string Notenrolled, string Hxbaker, string Meeting, string meetingtime,
             string School, string Reach,
             [Bind(Include = "Id,First_Name,Last_Name,Date_of_Birth,Primary_Caretaker_s_Name,Primary_Caretaker_s_Relationship" +
                ",Street_Address,Parents_Guardian_s_Email_Address,Parents_Guardian_s_Phone_number,Upcoming_meeting_scheduled_with_school," +
                "date,Is_the_youth_a_student_in_a_Duval_County_Public_School,Issues_Impacting_student,Where_is_the_youth_currently_attending_school," +
                "Is_there_anything_else_you_would_like_us_to_know_about_the_youth_or_their_family" +
                ",What_is_the_best_way_to_communicate_with_the_youth_family,zip_code,Status," +
                "Date_Referral_Input,email_address,Time")] Referral referral)



        {
            if (ModelState.IsValid)
            {



                //First Checkbox
                //answer equals checkboxes of guardians for client
                string answer = null;
                if (Mother != null)
                { answer = Mother + "," + ""; }
                if (Father != null)
                { answer = answer + Father + "," + ""; }
                if (Guardian != null)
                { answer = answer + Guardian + "," + ""; }
                if (Familymember != null)
                { answer = answer + Familymember + "," + ""; }
                if (FosterParent != null)
                { answer = answer + FosterParent + "," + ""; }
                if (VariableFM != null)
                { answer = answer + VariableFM + "," + ""; }
                referral.Primary_Caretaker_s_Relationship = answer;


                //Second Checkbox
                string answer1 = null;
                if (Failed != null)
                { answer1 = Failed + "," + ""; }
                if (Suspended != null)
                { answer1 = answer1 + Suspended + "," + ""; }
                if (Alt != null)
                { answer1 = answer1 + Alt + "," + ""; }
                if (Plan != null)
                { answer1 = answer1 + Plan + "," + ""; }
                if (Notenrolled != null)
                { answer1 = answer1 + Notenrolled + "," + ""; }
                if (Hxbaker != null)
                { answer1 = answer1 + Hxbaker + "," + ""; }
                referral.Issues_Impacting_student = answer1;


                referral.Is_the_youth_a_student_in_a_Duval_County_Public_School = School;

                referral.Upcoming_meeting_scheduled_with_school = Meeting;

                referral.Time = meetingtime;




                referral.What_is_the_best_way_to_communicate_with_the_youth_family = Reach;


                db.Configuration.ValidateOnSaveEnabled = false;
                db.Referrals.Add(referral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(referral);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
