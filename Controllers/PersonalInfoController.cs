using PPP_Loan_2.Models;
using PPP_Loan_2.Viewodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPP_Loan_2.Controllers
{
    public class PersonalInfoController : Controller
    {
        // GET: PersonalInfo
        public ActionResult PersonalInfoView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PersonalInfoView(string name)
        {
            PersonalViewModel personalObj = new PersonalViewModel();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-RURNJ5I\\tej;Initial Catalog=Commercial_DB;Integrated Security=True"))
            {
                string sqlQuery = "select * from APPLICANT where first_name='" + name + "'";
                con.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.Read())
                {
                    personalObj.applicant_id = Convert.ToInt32(sdr["applicant_id"]);
                }
                con.Close();
            }

            return View(personalObj);
        }
        [HttpPost]
        public ActionResult PersonalInfoView(PersonalViewModel personal)
        {

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-RURNJ5I\\tej;Initial Catalog=Commercial_DB;Integrated Security=True"))
            {
                PersonalModel personal1 = new PersonalModel();
                personal1.Role = personal.Role;
                personal1.SsnNumber = personal.SsnNumber;
               // personal1.ApplicantID = personal.applicant_id;

                con.Open();
                //using stored procedure
                using (SqlCommand cmd1 = new SqlCommand("sp_appUpdate", con))
                {
                    cmd1.Connection = con;

                    //con.Open();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    // Passing parameter values  
                    cmd1.Parameters.AddWithValue("@role", personal1.Role);
                    cmd1.Parameters.AddWithValue("@ssn", personal1.SsnNumber);
                    cmd1.Parameters.AddWithValue("@applicant_id", personal.applicant_id);
                    cmd1.Parameters.AddWithValue("@Query", 1);
                    // Executing stored procedure 
                    cmd1.ExecuteNonQuery();
                    //status = (cmd.ExecuteNonQuery() >= 1) ? "Record is saved Successfully!" : "Record is not saved";
                    con.Close();



                    PersonalAddressModel address = new PersonalAddressModel();
                    address.Street = personal.Street;
                    address.City = personal.City;
                    address.State = personal.State;
                    address.zipcode = personal.zipcode;
                    address.applicant_id = personal.applicant_id; ;

                    using (SqlCommand cmd2 = new SqlCommand("sp_applicant_address", con))
                    {
                        cmd2.Connection = con;

                        con.Open();

                        cmd2.CommandType = CommandType.StoredProcedure;
                        // Passing parameter values  
                        cmd2.Parameters.AddWithValue("@street_address", address.Street);
                        cmd2.Parameters.AddWithValue("@city", address.State);
                        cmd2.Parameters.AddWithValue("@state", address.City);
                        cmd2.Parameters.AddWithValue("@zipcode", address.zipcode);
                        cmd2.Parameters.AddWithValue("@applicant_id", address.applicant_id);
                        cmd2.Parameters.AddWithValue("@Query", 1);
                        // Executing stored procedure 
                        cmd2.ExecuteNonQuery();


                        //status += "<br/>";
                        //Session["business_name"] = business.BusinessName;
                        return RedirectToAction("BeneficialOwnership", "BeneficialOwner");

                    }

                    con.Close();
                }
                return View();
            }





        }
    }
}