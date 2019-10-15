using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HopePipeline.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult GenReports()
        {
            return View();
        }
    }
}