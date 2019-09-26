using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models
{
    public class FakeClientRepo : ClientRepository
    {
        public IEnumerable<Client> Clients => new List<Client>
        {
            new Client { ClientID = 1, Name = "David", Caregiver = "June", Gender = "Boy"},
            new Client { ClientID = 2 ,Name = "Kristina", Caregiver = "Karthik", Gender = "GIrl",}
        };
    }
}
