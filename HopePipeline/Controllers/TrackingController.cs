using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HopePipeline.Controllers
{
    public class TrackingController : Controller
    {
        public IActionResult StartTracking()
        {
            return View();
        }
    }
}