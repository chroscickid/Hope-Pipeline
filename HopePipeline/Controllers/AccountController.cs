using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HopePipeline.Models;
using System.Net.Mail;
using HopePipeline.Models.DbEntities;
using HopePipeline.Models.DbEntities.Login;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace HopePipeline.Controllers
{

    public class AccountController : Controller
    {
        public string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult newaccount(AdminRow acc)
        {
            SqlConnection con;
            con = new SqlConnection(connectionString);
            SqlCommand command;
            con.Open();

           string query = "INSERT INTO account VALUES('" + acc.email + "','" + acc.pass + "','" + acc.firstname + "','" + acc.lastname + "')";
           command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            //add reader for potential database errors
            return RedirectToAction("AdminList", "Account");
        }

        public ActionResult AdditionalAdmin()
        {
            return View();
        }

        public ActionResult Verify(Account acc)
        {
            SqlConnection con;
            con = new SqlConnection(connectionString);
            SqlCommand command;
            con.Open();

             string query = "select * from dbo.account where email='" + acc.email + "' and pass='" + acc.pass + "'";

            command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                con.Close();
                return RedirectToAction("RefList","Referral");
            }

            else
            {
                ViewBag.error = "Invalid Account";
                con.Close();
                return RedirectToAction("Index","Home");
            }
           
        }

        public ViewResult AdminList()
        {
            var results = new List<AdminRow>();
            //  string connectionString = "Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlConnection con;
            con = new SqlConnection(connectionString);
            SqlCommand command;
            con.Open();

            string query = "SELECT firstname, lastname, email from dbo.account;";
            command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                //We push information from the query into a row and onto the list of rows
                AdminRow row = new AdminRow { firstname = reader.GetString(0), lastname = reader.GetString(1), email = reader.GetString(2) };
                results.Add(row);
            }
            reader.Close();
            con.Close();

            return View("AdminList", results);
        }

        public IActionResult Delete( AdminRow acc)
        {
            SqlConnection con;
            con = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            con.Open();
           // string query = "INSERT INTO account VALUES('" + acc.email + "','" + acc.pass + "','" + acc.firstname + "','" + acc.lastname + "')";
            string query = "DELETE from account WHERE email = ('" + acc.email + "')";
            command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            return RedirectToAction("AdminList", "Account");
        }

    //[route("logout")]
    //[httpget]

    //public iactionresult logout()
    //{
    //    httpcontext.session.remove("username");
    //    return redirecttoaction("index", "home");
    //}


    //public actionresult forgotpassword()
    //{
    //    return view();
    //}

   // [httppost]
    //public actionresult sendforgotpassemail(forgotaccount account)
    //{
    //      mailmessage mail = new mailmessage();
    //                  smtpclient smtpserver = new smtpclient("smtp.gmail.com");
    //                  mail.from = new mailaddress("hopepipeline@gmail.com");
    //                  string rsemail = account.email;
    //                  mail.to.add(rsemail);

    //                  mail.subject = "forgot password link";
    //                  datetime date = datetime.now;
    //                  string mails = "placeholder. email is " + account.email;
    //                  mail.body = mails;



    //                  smtpserver.port = 587;
    //                  smtpserver.credentials = new system.net.networkcredential("hopepipeline@gmail.com", "referralinfo22");
    //                  smtpserver.enablessl = true;
    //                  smtpserver.send(mail);

    //    return redirecttoaction("index", "home");
    //}


}
    }
