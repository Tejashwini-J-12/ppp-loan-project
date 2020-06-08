using PPP_Loan_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PPP_Loan_2.Viewodel
{
    public class PersonalViewModel
    {
        public PersonalAddressModel Personaladdress { get; set; }
        public PersonalModel personalmodel { get; set; }
        //public int applicant_id { get; set; }

        [Required]
        [Display(Name = "How are you related to this business?")]
        public string Role { get; set; }

        [Required]
        [Display(Name = "Social Security Number(SSN)")]
        public int SsnNumber { get; set; }

        //[Required]
        //[DataType(DataType.PhoneNumber)]
        //[Display(Name = "Mobile Phone Number")]
        //public string Mobile { get; set; }

        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public int zipcode { get; set; }

        public int applicant_id { get; set; }
        [ForeignKey("applicant_id")]
        public virtual ApplicantModel applicants { get; set; }
    }
}