using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPP_Loan.Models
{
    public class Applicant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicantID { get; set; }

        [Required(ErrorMessage ="Please enter your First name")]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last name")]
        [Display(Name = "Last Name")]
        public string  LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Email Id")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string  EmailID { get; set; }

        [Required(ErrorMessage = "Please enter your Mobile number")]
        [Display(Name = "Mobile Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber{ get; set; }
    }
}