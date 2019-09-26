using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using Xceed.Wpf.Toolkit;

namespace HopePipeline.Controllers
{
    public class ClientController : Controller
    {
        public ClientRepository repository;
        public ClientController(ClientRepository repo)
        {
            repository = repo;
        }

        public ViewResult RefList() => View(repository.Clients);


        public ViewResult StartIntake(int m) => View(repository.Clients.FirstOrDefault(p => p.ClientID == m));
        

       public IActionResult EditReferral()
       {
            return View();
       }

       public IActionResult ViewMoreInfo()
        {
            return View();
        }
    }
}
