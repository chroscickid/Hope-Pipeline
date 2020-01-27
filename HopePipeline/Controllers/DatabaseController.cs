using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HopePipeline.Controllers
{
    public class DatabaseController : Controller
    {
        public string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public ActionResult PushFromStaging(int ClientCode)
        {
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT * FROM dbo.TrackingStage WHERE stageClientCode = " + ClientCode + ";";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                /*string com1 = "insert into dbo.accomodations (addAccom, accomGained, clientCode) VALUES ( " + reader.GetInt32(0) + "," + reader.GetString(1) + "," + ClientCode + ");";
                string com2 = "insert into dbo.advocacy (rearrestAdvo, courtAdvo, staffingAdvo, legalAdTaken, clientCode) VALUES ( " + reader.GetInt32(2) + "," + reader.GetInt32(3) + "," + reader.GetInt32(4) + "," + reader.GetInt32(4) + "," + ClientCode +");";
                 string com3 = "insert into dbo.advocacy (";*/
                /*for(int i = 0; i > 89; i++)
                {
                    reader.GetFieldType;
                }*/

                return View();
                
            }
            return View();

        }
    }
}