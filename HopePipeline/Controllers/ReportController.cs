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
        //This doesn't actually generate reports! This just calls the form
        public IActionResult GenerateReports()
        {            
            return View();
        }


        [HttpPost]
        public IActionResult ViewReports(ReportForm genReport)
        {
            //We call this so we can reference all the variables we need to
            Tracking reference = new Tracking();
            //This is a list of all the generated rows for the report
            var results = new List<ReportRow>();

            //An array of all the fields that were searched
            string[] texts = new string[] { genReport.field1, genReport.field2, genReport.field3, genReport.field4, genReport.field5 };
            string[] fields = new string[] { genReport.text1, genReport.text2, genReport.text3, genReport.text4, genReport.text5 };
            
            //Making sure that at least the first field was searched
            //This can be fleshed out later
            if (fields[0] == null)
            {
                return View("ReportError");
            }

            //Calling the SQL stuff
            string connectionString = "placeholder";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

           

            for (int i = 0; i < 5; i++)
            {
                string text = texts[i];
                string field = fields[i];

                //Since yes/no/maybe fields are represented as tinyints
                //We wanted CCR to be able to search these in plaintext, so we convert them
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
                //We generate a SQL query using the relevant field
                string query = "SELECT [firstname],[lastname]," + field + " FROM [TrackingTable] WHERE " + field + " = " + text;
                command = new SqlCommand(query, cnn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //We push information from the query into a row and onto the list of rows
                    ReportRow row = new ReportRow { fName = reader.GetString(0), lName = reader.GetString(1), releField1 = reader.GetString(2)};
                    results.Add(row);
                }
                reader.Close();



            }
            
            //Pushes the list and relevant field onto the results model, and sends it to the view
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