using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using System.Data.SqlClient;
using JsonFx.Serialization;
using HopePipeline.Models.DbEntities.Reports;

namespace HopePipeline.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult GenerateReports()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ViewReports(ReportForm genReport)
        {
            Tracking track = new Tracking();
            var results = new List<Report>();
            string[] texts = new string[] { genReport.field1, genReport.field2, genReport.field3, genReport.field4, genReport.field5 };
            string[] fields = new string[] { genReport.text1, genReport.text2, genReport.text3, genReport.text4, genReport.text5 };
            

            if (fields[0] == null)
            {
                return View("ReportError");
            }

            string connectionString = "hello???";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

           

            for (int i = 0; i < 5; i++)
            {
                string text = texts[i];
                string field = fields[i];
                if(checkifBool(field))
                {
                    switch (text)
                    {
                        case "yes":
                            text = "0";
                            break;
                        case "no":
                            text = "1";
                            break;
                        case "maybe":
                            text = "2";
                            break;
                        default:
                            text = null;
                            break;
                    }
                }

                string query = "SELECT [firstname],[lastname]," + field + " FROM [TrackingTable] WHERE " + field + " = " + text;
                command = new SqlCommand(query, cnn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Report row = new Report { fName = reader.GetString(0), lName = reader.GetString(1), releField1 = reader.GetString(2)};
                    results.Add(row);
                }
                reader.Close();



            }
            

            ReportResults toSend = new ReportResults { ResultsList = results, field = fields};
            return View("ReportResults", toSend);
            
        }

        public static bool checkifBool(string field)
        {
            //type up every element that should be a boolean (tinyint) here
            return false;
        }

        public FileResult ExportDB()
        {
            
            byte[] excelSheet = System.IO.File.ReadAllBytes("../HopePipeline/wwwroot/lib/hopetracking.xlsx");
            string fileName = "hopetracking.xlsx";
            return File(excelSheet, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}