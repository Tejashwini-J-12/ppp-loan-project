using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPP_Loan.Models
{
    public class AddressModel
    {
        [Required]
        public  string Street { get; set; }
        [Required]
        public string City { get; set; }
        public List<SelectListItem> States { get; set; }
        public int? StateId { get; set; }

        [Required]
        [Display(Name ="Zip Code")]
        public string zipcode { get; set; }
    }
}