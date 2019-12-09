using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models.DbEntities.Referrals
{
    public class Contact
    {
        string Fname { get; set; }
        string Lname { get; set; }
        
        string phone { get; set; }
        string cfirst { get; set; }
        string clast { get; set; }
        string relationship { get; set; }
        
        string rName { get; set; }

        string rEmail { get; set; }
        
    }
}
