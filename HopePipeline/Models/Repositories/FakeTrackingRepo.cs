using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopePipeline.Models
{
    public class FakeTrackingRepo //: TrackingRepository
    {
        public IEnumerable<Tracking> Referrals => new List<Tracking>
        {
           /* new Tracking { pK = 0, fName = "David", lName = "Chroscicki" , dOB = new DateTime(1996, 10, 17), status = "Pending"},
            new Tracking { pK = 1, fName = "Bridget", lName = "Lyon" , dOB = new DateTime(2002, 2, 10), status = "Pending"},
            new Tracking { pK = 2, fName = "Kristina", lName = "Huston" , dOB = new DateTime(1998, 4, 13), status = "Pending"},
            new Tracking { pK = 3, fName = "Lili", lName = "Weinstein" , dOB = new DateTime(1998, 4, 15), status = "Pending"}*/

        };
    }
}