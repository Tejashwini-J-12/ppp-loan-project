using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PPP_Loan_2.Models
{
    public class BusinessAddressModel
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public string zipcode { get; set; }

        //foreign key
        public int applicant_id { get; set; }
        [ForeignKey("applicant_id")]
        public virtual ApplicantModel applicants { get; set; }
    }
}
