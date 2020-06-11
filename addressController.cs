
using PPP_Loan.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPP_Loan.Controllers
{
    public class addressController : Controller
    {
        // GET: address
        public ActionResult Index()
        {
            AddressModel address = new AddressModel();
            address.States = PopulateStates();
            return View(address);

        }
        [HttpPost]
        public ActionResult Index(AddressModel address)
        {
            address.States = PopulateStates();
            var selectedItem = address.States.Find(p => p.Value == address.StateId.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = "State: " + selectedItem.Text;
                //ViewBag.Message += "\\nQuantity: " + fruit.Quantity;
            }

            return View(address);
        }

        private static List<SelectListItem> PopulateStates()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-RURNJ5I\\tej;Initial Catalog=Commercial_DB;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection(con))
            {
                string query = " SELECT state_name, state_id FROM STATES";
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["state_name"].ToString(),
                                Value = sdr["state_id"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;


        }
    }
}
