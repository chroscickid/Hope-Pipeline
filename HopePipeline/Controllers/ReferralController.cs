using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;

namespace HopePipeline.Controllers
{
    public class ReferralController : Controller
    {
        public ReferralRepository repository;
        public ReferralController(ReferralRepository repo)
        {
            repository = repo;            
        }

        public ViewResult RefList() => View(repository.Referrals);

        


        /*public IActionResult Details(int det)
         {

             return View(pK);
         }*/
        [Route("Referral/{pK:int}")]
        public IActionResult Detail(int id)
        {
            return View();
        }

  
        
    }
}
