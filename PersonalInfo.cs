using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PPP_Loan.Models
{
    public class PersonalInfo
    {
        [Key]
        public string ApplicantID { get; set; }

        [Required]
        [Display(Name = "How are you related to this business?")]
        public string  Role { get; set; }

        [Required]
        [Display(Name = "Social Security Number(SSN)")]
        public string SsnNumber  { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Phone Number")]
        public string Mobile { get; set; }
    }
}