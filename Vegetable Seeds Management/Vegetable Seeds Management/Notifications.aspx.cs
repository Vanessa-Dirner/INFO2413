﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Vegetable_Seeds_Management
{
    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void WastedSeedsReport_Click(object sender, EventArgs e)
        {

                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-UB0LHNH;Initial Catalog=project;Integrated Security=True"))
                {
                    string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainconn);
                    sqlconn.Open();
                    Response.Write("Connection Established...");
                    SqlCommand sqlcomm = new SqlCommand();
                    string sqlquery = "SELECT * FROM waste order by quantity desc";
                    sqlcomm.CommandText = sqlquery;
                    sqlcomm.Connection = sqlconn;
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                    sda.Fill(dt);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    sqlconn.Close();
                }
                
        }

        protected void HarvestedSeedsReport_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-UB0LHNH;Initial Catalog=project;Integrated Security=True"))
            {
                string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                sqlconn.Open();
                Response.Write("HIII");
                SqlCommand sqlcomm = new SqlCommand();
                string sqlquery = "SELECT * FROM inventory";
                sqlcomm.CommandText = sqlquery;
                sqlcomm.Connection = sqlconn;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                sda.Fill(dt);
                GridView2.DataSource = dt;
                GridView2.DataBind();
                sqlconn.Close();
            }
        }


            protected void WastedReport_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}

    /*
     * // Get seeds expiring in 1 year or less
                    sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand(WastedSeeds, sqlCon);
                        string WastedSeeds = "SELECT * FROM waste order by quantity desc";
                       
                        // notify
                        if (!string.IsNullOrEmpty(WastedSeeds))
                        {
                            Console.WriteLine("The following seeds are expiring within 1 year: ");
                            Console.WriteLine("expiringSeeds");
                        }
                        else
                        {
                            Console.WriteLine("No data is available.");
                        }
                    }


/*
 
        public class expirynotify
        {
            public expirynotify()
            {
                
                // if seeds have expired, move to expired table
                /* string expiredSeeds = "SELECT * FROM inventory WHERE expirationdate < getdate()"

                     if (string.IsNullOrEmpty(expiredSeeds))
                             {
                                 string moveExpiredSeeds = "BEGIN TRANSACTION; INSERT INTO waste; SELECT * FROM inventory WHERE expirationdate < getdate(); DELETE FROM inventorywhere expirationdate < getdate(); COMMIT "
                         SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                 sqlCmd.Parameters.AddWithValue(moveExpiredSeeds)
                     }
                
                // email notification to administrator

            }
        }
        
 */

/*
 * 
 * using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-UB0LHNH;Initial Catalog=project;Integrated Security=True"))

            // Get seeds expiring in 1 year or less
            sqlCon.Open();
            string expiringSeeds = "SELECT * FROM inventory WHERE expirationdate >= dateadd(year, +1, getdate())";
            // notify
            if (string.IsNullOrEmpty(expiringSeeds))
            {
                Console.WriteLine("The following seeds are expiring within 1 year: ");
                Console.WriteLine("expiringSeeds");
            }

 * 
 * */