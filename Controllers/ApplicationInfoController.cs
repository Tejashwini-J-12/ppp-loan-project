using PPP_Loan_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PPP_Loan_2.Controllers
{
    public class ApplicationInfoController : Controller
    {
        // GET: Applicant
        public ActionResult Application()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Application(ApplicantModel applicant)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-RURNJ5I\\tej;Initial Catalog=Commercial_DB;Integrated Security=True"))
            {
                
                using (SqlCommand cmd = new SqlCommand("sp_appInsert", con))
                {
                    cmd.Connection = con;
                    
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Passing parameter values  
                    cmd.Parameters.AddWithValue("@first_name", applicant.first_name);
                    cmd.Parameters.AddWithValue("@last_name", applicant.last_name);
                    cmd.Parameters.AddWithValue("@email", applicant.email);
                    cmd.Parameters.AddWithValue("@mobile", applicant.phone);
                    cmd.Parameters.AddWithValue("@Query", 1);
                  
                    // Executing stored procedure 
                    cmd.ExecuteNonQuery();
                     
                    Session["first_name"] = applicant.first_name;
                    return RedirectToAction("welcome");

                }
                
                con.Close();
            }
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }

    }
}