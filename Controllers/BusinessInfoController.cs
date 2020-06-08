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
    public class BusinessInfoController : Controller
    {
        // GET: BusinessInfo
        public ActionResult BusinessView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BusinessView(string name)
        {
            BusinessViewModel businessObj = new BusinessViewModel();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-RURNJ5I\\tej;Initial Catalog=Commercial_DB;Integrated Security=True"))
            {
                string sqlQuery = "select * from APPLICANT where first_name='" + name + "'";
                con.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.Read())
                {
                    businessObj.applicant_id = Convert.ToInt32(sdr["applicant_id"]);
                }
                con.Close();
            }

            return View(businessObj);
        }

        [HttpPost]
        public ActionResult BusinessView(BusinessViewModel business)
        {

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-RURNJ5I\\tej;Initial Catalog=Commercial_DB;Integrated Security=True"))
            {
                BusinessInfoModel business1 = new BusinessInfoModel();
                business1.BusinessName = business.BusinessName;
                business1.AnnualRevenue = business.AnnualRevenue;
                business1.TIN = business.TIN;
                business1.IndustryType = business.IndustryType;
                business1.NoOfEmp = business.NoOfEmp;
                business1.BusinessEntity = business.BusinessEntity;
                business1.BusinessDBA = business.BusinessDBA;
                business1.BusinessDate = business.BusinessDate;
                business1.NAICS = business.NAICS;
                business1.applicant_id = business.applicant_id;

                con.Open();
                //using stored procedure
                using (SqlCommand cmd1 = new SqlCommand("sp_business", con))
                {
                    cmd1.Connection = con;

                    //con.Open();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    // Passing parameter values  
                    cmd1.Parameters.AddWithValue("@business_name", business1.BusinessName);
                    cmd1.Parameters.AddWithValue("@turnover_amount", business1.AnnualRevenue);
                    cmd1.Parameters.AddWithValue("@tin", business1.TIN);
                    cmd1.Parameters.AddWithValue("@industry_type", business1.IndustryType);
                    cmd1.Parameters.AddWithValue("@emp_number", business1.NoOfEmp);
                    cmd1.Parameters.AddWithValue("@business_entity_type", business1.BusinessEntity);
                    cmd1.Parameters.AddWithValue("@business_dba", business1.BusinessDBA);
                    cmd1.Parameters.AddWithValue("@date_of_establishment", business1.BusinessDate);
                    cmd1.Parameters.AddWithValue("@naics_code", business1.NAICS);
                    cmd1.Parameters.AddWithValue("@applicant_id", business1.applicant_id);
                    cmd1.Parameters.AddWithValue("@Query", 1);
                    // Executing stored procedure 
                    cmd1.ExecuteNonQuery();
                    //status = (cmd.ExecuteNonQuery() >= 1) ? "Record is saved Successfully!" : "Record is not saved";
                    con.Close();


                   // int latestBusinessID = business1.BusinessID;
                    BusinessAddressModel address = new BusinessAddressModel();
                    address.Street = business.Street;
                    address.City = business.City;
                    address.State = business.State;
                    address.zipcode = business.zipcode;
                    address.applicant_id = business.applicant_id; ;

                    using (SqlCommand cmd2 = new SqlCommand("sp_business_address", con))
                    {
                        cmd2.Connection = con;

                        con.Open();
                        // int business_id = address.BusinessID;
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
                        Session["business_name"] = business.BusinessName;
                        return RedirectToAction("PersonalInfoView", "PersonalInfo");

                    }
                    /*
                    using (SqlCommand cmdd = new SqlCommand("select * from APPLICANT where first_name="+ applicant.first_name,con))
                    {
                        cmdd.Connection = con;
                        //con.Open();
                        SqlDataReader sdr = cmdd.ExecuteReader();
                        if (sdr.Read())
                        {
                            Session["applicant_id"] = sdr["applicant_id"].ToString();

                        }

                    }

                  */
                    con.Close();
                }
                return View();
            }

            //public ActionResult BWelcome()
            //{
            //    return View();
            //}
        }
    }
}



