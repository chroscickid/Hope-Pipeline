using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Referrals;

namespace HopePipeline.Controllers
{
    public class nController:Controller
    {
        public IActionResult formReferralM()
        {
            string connectionString = "Data Source=iscrew.database.windows.net;Initial Catalog=HopePipeline;User ID=user;Password=pAssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
          
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command = cnn.CreateCommand();
            object value = new SqlCommand("SELECT MAX(clientCode) FROM refform", cnn).ExecuteScalar();
            if (value == null)
            { value = 0; }
            int i = (int)value;
            
          
            //SELECT MAX(Price) AS LargestPrice
            //FROM Products;
            ViewBag.Tessage =i+1;
            cnn.Close();
            return View();
          
        }
        [HttpPost]
        public IActionResult submitform(referralBrandi form)
        {
            string connectionString = "Data Source=iscrew.database.windows.net;Initial Catalog=HopePipeline;User ID=user;Password=pAssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "INSERT INTO dbo.refform VALUES ('" + form.clientCode + "', '" + form.fName + "', '" + form.lName + "', '" + form.dOB + "', '" + form.guardianName + "', '" + form.guardianRelationship + "', '" + form.address + "', '" + form.gender + "', '" + form.guardianEmail + "', '" + form.guardianPhone + "', '" + form.meeting + "', '" + form.youthInDuvalSchool + "', '" + form.youthInSchool + "', '" + form.issues + "', '" + form.currentSchool + "', '" + form.otherInfo + "', '" + form.communication + "', '" + form.zip + "', '" + form.grade + "', '" + form.status + "', '" + form.arrest + "', '" + form.school + "', '" + form.dateInput + "', '" + form.date + "', '" + form.email + "', '" + form.Reach + "', '" + form.moreInfo + "', '" + form.referralfname + "', '" + form.referrallname + "')";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            //COnnect to the DB
              
           
      
            return RedirectToAction("Index","Home");

        }
        public IActionResult confirmationM()
        {
            return View();

        }
        public IActionResult contactInfoM(int clientCode)
        {
            //string connectionString = "Data Source=iscrew.database.windows.net;Initial Catalog=HopePipeline;User ID=user;Password=pAssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            
          /*  SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT fname, lname, guardianName, guardianRelationship, guardianPhone, strAddress, zip FROM refform WHERE clientCode = " + clientCode + ";";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            while (reader.Read())
            {

                //We push information from the query into a row and onto the list of rows
                RefRow row = new RefRow { fname = reader.GetString(0), lname = reader.GetString(1), dob = reader.GetDateTime(2).ToString("dd MMMM yyyy"), clientCode = reader.GetInt32(3) };
            }
            reader.Close();

            cnn.Close();*/
            return View();




        }
        public IActionResult detailReferralM(int clientCode)
        {

            string connectionString = "Data Source=iscrew.database.windows.net;Initial Catalog=HopePipeline;User ID=user;Password=pAssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT * FROM refform WHERE clientCode = " + clientCode + ";";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            cnn.Close();
            return View();

        }
        public IActionResult detailTrackingM()
        {

            return View();

        }
        public IActionResult EditTrackingM(int clientCode)
        {
            return View();

        }
        public IActionResult editReferrall(referralBrandi form)
        {


            string connectionString = "Data Source=iscrew.database.windows.net;Initial Catalog=HopePipeline;User ID=user;Password=pAssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command = cnn.CreateCommand();
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //cnn.Open();
            command.CommandText = "UPDATE refform SET [fname]= '" + form.clientCode + "', [lname] = '" + form.lName + "', [dob] = '" + form.dOB + "', [guardianName]= '" + form.guardianName + "', [guardianRelationship]= '" + form.guardianRelationship +
                "'," +
                " [strAddress]= '" + form.address + "', [gender]  = '" + form.gender + "', [guardianEmail] = '" + form.guardianEmail + "', [guardianPhone]='" + form.guardianPhone + "' ," +
                " [meeting] ='" + form.meeting + ", [youthInDuvalSchool]= '" + form.youthInDuvalSchool + "', [youthInSchool] = '"
                + form.youthInSchool + "', [issues]='"+ form.issues + "', [currentSchool] ='" + form.currentSchool + "' ,[otherInfo] = '" + form.otherInfo + "', [communication] ='" +form.communication + "'," +
                "[zip] ='" + form.zip + "', [grade] = '" + form.grade + "', [currStatus] = '" + form.status + "', [arrest] ='" + form.arrest + "'," +
                " [school] ='"+ form.school + "', [dateInput] = '" + form.dateInput + "', [meetingDate] ='" + form.date + "', [email] ='" + form.email + "', [reach] ='" + form.Reach + "'" +
                ", [moreInfo] ='" + form.moreInfo + "', [reason] ='" + form.reason + "'," +
                " [referralfname] ='" +
            form.referralfname + "', [referrallname] ='" + form.referrallname + "')" +
                " WHERE [clientCode] = " + form.clientCode + ";";
            cnn.Open();

            command.ExecuteNonQuery();
            // SqlCommand command = new SqlCommand(query, cnn);
            cnn.Close();



            return RedirectToAction("Index", "Home");

        }
        public IActionResult editReferralM(int clientCode)
        {

            return View();



        }
    }
}
