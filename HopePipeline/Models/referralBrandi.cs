

namespace HopePipeline.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class referralBrandi
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int pK { get; set; }

        public string fName { get; set; }

        public string lName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dOB { get; set; }

        public string guardianName { get; set; }

        public string guardianRelationship { get; set; }

        public string address { get; set; }


        public string guardianEmail { get; set; }


        public string guardianPhone { get; set; }

        public string meeting { get; set; }





        public string youthInSchool { get; set; }
        public string issues { get; set; }

        public string currentSchool { get; set; }

        public string otherInfo { get; set; }

        public string communication { get; set; }

        public string zip { get; set; }


        public string status { get; set; }


        public Nullable<System.DateTime> dateInput { get; set; }
        [DataType(DataType.Date)]
        public DateTime? date { get; set; }

        public string email { get; set; }

        public string time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<filesReferralBrandi> filesReferralBrandi { get; set; }
        public virtual ICollection<trackingReferral> trackingReferral { get; set; }

    }
}
