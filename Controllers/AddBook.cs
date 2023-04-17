using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureExampleWithDB.Controllers
{
    public class AddBook : Controller
    {
        public ActionResult Index()
        {
            var connectionString = "Server=tcp:server14235.database.windows.net,1433; Initial Catalog = newdb; Persist Security Info = False; User ID = sa124312; Password =444555Ze$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = true; Connection Timeout = 30;";
            string[] str = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            using (var conn = new SqlConnection(connectionString))
            {
                var strQuery = "SELECT * FROM [Books]";
                conn.Open();
                SqlCommand command1 = new SqlCommand(strQuery, conn);
                var cmdSelectFromProduct = command1.ExecuteScalar();

                System.Data.DataTable table = new System.Data.DataTable();




                SqlDataReader dr = command1.ExecuteReader();
                //cmbRefCpv.Items.Add("All");
                //cmbRefCpv.Text = "All";
                //chkAllRefCpv.Checked = true;
                int i = 0;
                
                while (dr.Read())
                {
                    str[i] = dr[0].ToString() + " . " + dr[1].ToString() + " - " + dr[2].ToString();
                    i++;
                }

                dr.Close();
                conn.Close();
            }
            return View(str);
        }
    }
}