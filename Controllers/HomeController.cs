using AzureExampleWithDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AzureExampleWithDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var connectionString = WebConfigurationManager.AppSettings["ConnStr"];
             string[] str = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            using (var conn = new SqlConnection(connectionString))
            {
                var strQuery = "select * from [Books] order by ID";
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
                    str[i] = dr[0].ToString() + " , " + dr[1].ToString() + " , " + dr[2].ToString();
                    i++;                   
                }

                dr.Close();
                conn.Close();
            }
            return View(str);
        }

        
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //public ActionResult AddBook()
        //{
            

        //}
        private void alert(string v)
        {
            throw new NotImplementedException();
        }

        public ActionResult About()
        {
            ViewBag.Message = "List of Books";

            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
        public ActionResult BookForm()
        {


            return View();
        }
        [HttpPost]
       
        public ActionResult AddBook(AzureExampleWithDB.Models.Book model)
        {
            var connectionString = WebConfigurationManager.AppSettings["ConnStr"];
            string[] str = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };


            var Title = Request["Title"].ToString();
            var Author = Request["Author"].ToString();
            Title = Title.Replace("'", "");
            Author = Author.Replace("'", "");
            using (var conn = new SqlConnection(connectionString))
            {



                var strQuery = "Select max(ID) from [Books]";
                    
                    
                   
                conn.Open();
                SqlCommand command1 = new SqlCommand(strQuery, conn);
                var cmdSelectFromProduct = command1.ExecuteScalar();

                SqlDataReader dr = command1.ExecuteReader();

                var MaxNum = 0;
                while (dr.Read())
                {
                    MaxNum = (int)dr[0];
                  
                }
                MaxNum++;
                dr.Close();

                strQuery = "insert into [Books] select " + MaxNum + ", '" + Title + "','" + Author + "'";

                command1 = new SqlCommand(strQuery, conn);
                cmdSelectFromProduct = command1.ExecuteScalar();

                

                strQuery = "select * from [Books] order by ID";

                

                var command2 = new SqlCommand(strQuery, conn);
                cmdSelectFromProduct = command2.ExecuteScalar();
                SqlDataReader dr2 = command2.ExecuteReader();

                //cmbRefCpv.Items.Add("All");
                //cmbRefCpv.Text = "All";
                //chkAllRefCpv.Checked = true;
                int i = 0;
                while (dr2.Read())
                {
                    str[i] = dr2[0].ToString() + " , " + dr2[1].ToString() + " , " + dr2[2].ToString();
                    i++;
                }


                
                dr2.Close();
                conn.Close();
            }
            return View();
        }
    }
}