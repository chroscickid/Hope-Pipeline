using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models.DbEntities.Referrals;
using HopePipeline.Models;
using System.Data.SqlClient;

namespace HopePipeline.Controllers
{
    public class ReferralController : Controller
    {
        public ReferralRepository repository;
        public ReferralController(ReferralRepository repo)
        {
            repository = repo;            
        }

      //  public ViewResult RefList() => View(repository.Referrals);
         public ViewResult RefList()
        {
            var results = new List<RefRow>();
            string connectionString = "Server=tcp:iscrew.database.windows.net,1433;Initial Catalog=HopePipeline1;Persist Security Info=False;User ID=user;Password=pAssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "select clientFirst, clientLast, dob, clientCode from dbo.client";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //We push information from the query into a row and onto the list of rows
                RefRow row = new RefRow { fname = reader.GetString(0), lname = reader.GetString(1), dob = reader.GetString(2), clientCode = reader.GetString(3)};
                results.Add(row);
            }
            reader.Close();

            return View("RefList", results);
        }

        public ViewResult Delete(int pk)
        {
            string connectionString = "placeholder";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "DELETE from [referral table] WHERE [PK] = " + pk + ";";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            return View("RefList");
        }

        


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
