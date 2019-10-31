using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;

namespace HopePipeline.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult GenerateReports()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ViewReports(Report report)
        {
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            string repor = "There are " + count1 + " clients that fit the criteria: " + report.demoField1 + " " + report.demoField1relation + " and " + report.demoField2 + " " + report.demoField2relation + " where " + report.otherField;
           // string poop = report.demoField1;

            return Content(repor);
        }

        public FileResult ExportDB()
        {
            
            byte[] excelSheet = System.IO.File.ReadAllBytes("../HopePipeline/wwwroot/lib/hopetracking.xlsx");
            string fileName = "hopetracking.xlsx";
            return File(excelSheet, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}