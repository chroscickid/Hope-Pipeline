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
            new Client { ClientID = 1, Name = "David", Caregiver = "June", DoB = "October 17th"},
            new Client { ClientID = 2 ,Name = "Kristina", Caregiver = "Karthik", DoB = "Feb 14th"},
            new Client { ClientID = 3 ,Name = "Flo", Caregiver = "rida", DoB = "Feb 14th",}
        };
    }
}