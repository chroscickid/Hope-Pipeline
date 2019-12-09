using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models.DbEntities.Referrals
{
    public class RefRow
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string dob { get; set; }
        public string status { get; set; }
        public string phone { get; set; }

        public int clientCode { get; set; }

    }
}
