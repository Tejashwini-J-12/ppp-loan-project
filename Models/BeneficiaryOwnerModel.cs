using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPP_Loan_2.Models
{
    public class BeneficiaryOwnerModel
    {
        [Key]
        public int BeneficiaryID { get; set; }

        [Required(ErrorMessage ="Enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Enter phone number")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter Role in Business")]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}