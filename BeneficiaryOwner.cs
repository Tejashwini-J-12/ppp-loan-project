using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PPP_Loan.Models
{
    public class BeneficiaryOwner
    {
        [Key]
        public int BeneficiaryID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Required]
        [Display(Name = "Mobile Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}