using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PPP_Loan_2.Models
{
    public class BusinessInfoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusinessID { get; set; }


        [Required(ErrorMessage = "Enter Business Name")]
        [Display(Name = "Legal Business Name")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Enter Annual Revenue")]
        [Display(Name = "Annual Revenue")]
        public decimal AnnualRevenue { get; set; }

        [Required(ErrorMessage = "Enter TIN")]
        [Display(Name = "Tax Identification Number")]
        public string TIN { get; set; }

        [Required(ErrorMessage = "Enter Industry Type")]
        [Display(Name = "What industry does your business belong to?")]
        public string IndustryType { get; set; }

        [Required(ErrorMessage = "Enter Number of employees")]
        [Display(Name = "Number of Employees")]
        public int NoOfEmp { get; set; }

        [Required(ErrorMessage = "Enter Business Entity Type")]
        [Display(Name = "Business Entity Type")]
        public string BusinessEntity { get; set; }

        [Required(ErrorMessage = "Enter Business DBA Name")]
        [Display(Name = "Business DBA Name(assumed trade name)")]
        public string BusinessDBA { get; set; }

        [Required(ErrorMessage = "Enter Business Start Date")]
        [Display(Name = "Date Business Established(DD/MM/YYYY)")]
        public DateTime BusinessDate { get; set; }


        [Required(ErrorMessage = "Enter NAICS code")]
        [RegularExpression("^[1 - 9]{5} ", ErrorMessage = "number should be 6 digits")]
       [Display(Name = "NAICS Code")]
        public string NAICS { get; set; }

        //foreign key
        public int applicant_id { get; set; }
        [ForeignKey("applicant_id")]
        public virtual ApplicantModel applicants { get; set; }
    }
}