using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HopePipeline.Models
{
    public class Referral
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        //done
        public string First_Name { get; set; }
        //done
        public string Last_Name { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date_of_Birth { get; set; }
        //done
        public string Primary_Caretaker_s_Name { get; set; }
        //done
        public string Primary_Caretaker_s_Relationship { get; set; }
        //done
        public string Street_Address { get; set; }
        //done
        [Required(ErrorMessage = "Please Provide a Email Address", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        public string Parents_Guardian_s_Email_Address { get; set; }
        //done
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "This a Required Field", AllowEmptyStrings = false)]
        public string Parents_Guardian_s_Phone_number { get; set; }

        public string Upcoming_meeting_scheduled_with_school { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date { get; set; }

        public string Is_the_youth_a_student_in_a_Duval_County_Public_School { get; set; }
        public string Issues_Impacting_student { get; set; }
        //done
        public string Where_is_the_youth_currently_attending_school { get; set; }
        //done
        public string Is_there_anything_else_you_would_like_us_to_know_about_the_youth_or_their_family { get; set; }

        public string What_is_the_best_way_to_communicate_with_the_youth_family { get; set; }

        //done
        public string zip_code { get; set; }

        //auto input
        public string Status { get; set; }
        //done
        public Nullable<System.DateTime> Date_Referral_Input { get; set; }

        [Required(ErrorMessage = "Please Provide a Email Address", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        public string email_address { get; set; }
        public string Time { get; set; }
    }
}
