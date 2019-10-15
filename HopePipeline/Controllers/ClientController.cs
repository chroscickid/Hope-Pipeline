using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;

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


        public ViewResult StartTracking()
        {
            return View();
        }

       public IActionResult EditReferral()
       {
            return View();
       }
       
      /* public IActionResult Delete(int deletee)
        {
            var list = repository.Clients;
            foreach(Client Cl in repository.Clients)
            {
                if (Cl.ClientID == deletee)
                    repository.Clients.ToList.R
                    
            }



            
            return View("RefList", repository.Clients);
        }*/

       public IActionResult ViewMoreInfo()
        {
            return View();
        }
    }
}
