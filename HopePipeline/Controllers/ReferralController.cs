using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public ViewResult RefList() => View(repository.Referrals);

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
