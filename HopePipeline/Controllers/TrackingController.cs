using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HopePipeline.Controllers
{
    public class TrackingController : Controller
    {
        public IActionResult demoTracking()
        {
            return View();
        }

        public ViewResult ccrTracking()
        {
            return View();
        }

        public ViewResult schoolTracking()
        {
            return View();
        }

        public ViewResult disciplineTracking()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitTracking()
        {
            return View();
        }
    }
}