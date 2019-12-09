using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Tracking;

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
            var results = new List<TrackingRow>();
            string connectionString = "Server=tcp:iscrew.database.windows.net,1433;Initial Catalog=HopePipeline1;Persist Security Info=False;User ID=user;Password=pAssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "select clientFirst, clientLast, clientCode from dbo.client";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //We push information from the query into a row and onto the list of rows
                TrackingRow row = new TrackingRow { fname = reader.GetString(0), lname = reader.GetString(1), clientCode = reader.GetString(3) };
                results.Add(row);
            }
            reader.Close();

            return View("RefList", results);
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