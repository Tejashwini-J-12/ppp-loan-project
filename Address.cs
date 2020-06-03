using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace PPP_Loan.Models
{
    public class Address
    {
        [Required]
        public  string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string  State { get; set; }
        [Required]
        [Display(Name ="Zip")]
        public string zipcode { get; set; }
    }
}