using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Tracking;
using HopePipeline.Models.Contexts;

namespace HopePipeline.Controllers
{
    public class TrackingController : Controller
    {
        public string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public ViewResult TrackingForm(string clientCode)
        {
            TrackingForm newF = new TrackingForm();
            var relRef = new referralBrandi();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "select * from dbo.refform where clientCode = " + clientCode;
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                relRef.address = reader.GetString(reader.GetOrdinal("strAddress"));
                relRef.arrest = reader.GetInt32(reader.GetOrdinal("arrest"));
                relRef.currentSchool = reader.GetString(reader.GetOrdinal("currentSchool"));
                //relRef.date = reader.GetDateTime(reader.GetOrdinal("date"));
              //  relRef.dateInput = reader.GetDateTime(reader.GetOrdinal("dateInput"));
                relRef.dOB = reader.GetDateTime(reader.GetOrdinal("dob"));
                relRef.email = reader.GetString(reader.GetOrdinal("email"));
                relRef.fName = reader.GetString(reader.GetOrdinal("fname"));
                relRef.gender = reader.GetString(reader.GetOrdinal("gender"));
                relRef.grade = reader.GetString(reader.GetOrdinal("grade"));
                relRef.guardianEmail = reader.GetString(reader.GetOrdinal("guardianEmail"));
               relRef.guardianName = reader.GetString(reader.GetOrdinal("guardianName"));
                relRef.guardianPhone = reader.GetString(reader.GetOrdinal("guardianPhone"));
                relRef.guardianRelationship = reader.GetString(reader.GetOrdinal("guardianRelationship"));
                relRef.issues = reader.GetString(reader.GetOrdinal("issues"));
                relRef.lName = reader.GetString(reader.GetOrdinal("lname"));
                relRef.meeting = reader.GetInt32(reader.GetOrdinal("meeting"));
                relRef.moreInfo = reader.GetString(reader.GetOrdinal("moreInfo"));
                relRef.Reach = reader.GetString(reader.GetOrdinal("Reach"));
                relRef.reason = reader.GetString(reader.GetOrdinal("reason"));
                relRef.referralfname = reader.GetString(reader.GetOrdinal("referralfname"));
                relRef.referrallname = reader.GetString(reader.GetOrdinal("referrallname"));
                relRef.school = reader.GetString(reader.GetOrdinal("school"));
                relRef.status = reader.GetString(reader.GetOrdinal("currStatus"));
                relRef.youthInDuvalSchool = reader.GetInt32(reader.GetOrdinal("youthInDuvalSchool"));
                relRef.youthInSchool = reader.GetInt32(reader.GetOrdinal("youthInSchool"));
                relRef.zip = reader.GetString(reader.GetOrdinal("zip"));       


            }
            reader.Close();

            newF.referralBrandi = relRef;


            //do black magic to get a model using the client code
            return View(newF);
        }
      
        [HttpPost]
        public IActionResult SubmitTracking()
        {
            return View();
        }

        public ViewResult TrackingList()
        {
            var results = new List<TrackingRow>();
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT clientLast, clientFirst, dbo.ccr.ccrStatus, dbo.client.clientCode FROM dbo.client INNER JOIN dbo.ccr ON dbo.client.clientCode = dbo.ccr.clientCode;";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //We push information from the query into a row and onto the list of rows
               // TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = reader.GetString(2), clientCode = reader.GetString(3) };
                TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = reader.GetInt32(2), clientCode = reader.GetInt32(3) };

                results.Add(row);
            }
            reader.Close();

            return View("TrackingList", results);
        }

      
        [HttpPost]
        public IActionResult Search(TrackingForm model)
        {
            string retur = model.firstName;
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