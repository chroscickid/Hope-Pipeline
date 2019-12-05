using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using System.Data.SqlClient;

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

        public ViewResult TrackingList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(Tracking model)
        {
            string retur = model.Name;
            return Content(retur);
        }

        public ViewResult Delete(int ClientID)
        {
            string connectionString = "placeholder";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "DELETE from [tracking table] WHERE [ClientID] = " + ClientID + ";";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            return View("TrackingList");
        }
    }
}