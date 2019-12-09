using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Controllers
{
    public class nController:Controller
    {
        public IActionResult formReferralM()
        {
            return View();

        }
        public IActionResult confirmationM()
        {
            return View();

        }
        public IActionResult contactInfoM(string clientCode)
        {

            List<object> myModel = new List<object>();
            ViewData["Message"] = "Contact Information for clients.";

            var list = from r in db.client
                       where (r.clientCode == clientCode)
                       select r;
            var list2 = from r in db.caregiver
                        where (r.clientCode == clientCode)
                        select r;
            var list3 = from r in db.referral
                        where (r.clientCode == clientCode)
                        select r;

            myModel.Add(list.ToList());
            myModel.Add(list2.ToList());
            myModel.Add(list3.ToList());
            return View(myModel);

        }
        public IActionResult detailReferralM()
        {
            return View();

        }
        public IActionResult detailTrackingM()
        {
            return View();

        }
        public IActionResult EditTrackingM()
        {
            return View();

        }
        public IActionResult editReferralM()
        {
            return View();

        }
    }
}
