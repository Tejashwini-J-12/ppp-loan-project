using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPP_Loan_2.Models
{
    public class PersonalModel
    {
        [Key]
        public int ApplicantID { get; set; }

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
    }
}
