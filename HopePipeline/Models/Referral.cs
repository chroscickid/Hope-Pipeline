

namespace HopePipeline.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Referral
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Referral()
        {
            this.FilesReferrals = new HashSet<FilesReferrals>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pK { get; set; }
        //done
        public string fName { get; set; }
        //done
        public string lName { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dOB { get; set; }
        //done
        public string guardianName { get; set; }
        //done
        public string guardianRelationship { get; set; }
        //done
        public string address { get; set; }
        //done
        [Required(ErrorMessage = "Please Provide a Email Address", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        public string guardianEmail { get; set; }
        //done
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "This a Required Field", AllowEmptyStrings = false)]
        public string guardianPhone { get; set; }

        public string meeting { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date { get; set; }

        public string youthInSchool { get; set; }
        public string issues { get; set; }
        //done
        public string currentSchool { get; set; }
        //done
        public string otherInfo { get; set; }

        public string communication { get; set; }

        //done
        public string zip { get; set; }

        //auto input
        public string status { get; set; }
        //done
        public Nullable<System.DateTime> dateInput { get; set; }

        [Required(ErrorMessage = "Please Provide a Email Address", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        public string email { get; set; }
        public string time { get; set; }

         [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesReferrals> FilesReferrals { get; set; }
        
    }
}
