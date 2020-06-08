using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PPP_Loan_2.Models
{
    public class ApplicantModel
    {
        [Key]
        public int applicant_id { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        [Display(Name = "First Name")]
        public string first_name { get; set; }


        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }


        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }


        [Required(ErrorMessage = "Enter Phone No")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public long phone { get; set; }


        //[Required(ErrorMessage = "Enter role")]
        //[Display(Name = "How are you related to this business?")]
        //public string role { get; set; }


        //[Required(ErrorMessage = "Enter ssn")]
        //[Display(Name = "SSN")]
        //public long ssn { get; set; }
    }
}