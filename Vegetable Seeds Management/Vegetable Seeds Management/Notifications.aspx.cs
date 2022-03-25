using System;
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
                    SqlCommand sqlcomm = new SqlCommand();
                    string sqlquery = " SELECT TOP 5 quantity, seedname, wasteid, expirationdate FROM waste WHERE expirationdate  > DATEADD(year,-1,GETDATE()) ORDER BY quantity DESC"; 
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
                SqlCommand sqlcomm = new SqlCommand();
                string sqlquery = " SELECT TOP 5 quantity, seedname, batch, aquirydate FROM inventory WHERE seedtype = 'harvested' AND aquirydate  > DATEADD(year,-1,GETDATE()) ORDER BY quantity DESC";       
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

        protected void PlantedSeedsReport_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-UB0LHNH;Initial Catalog=project;Integrated Security=True"))
            {
                string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand();
                string sqlquery = "SELECT * FROM planted WHERE dateplanted >= DATEADD(day,-30,GETDATE()) and dateplanted <= getdate()";
                sqlcomm.CommandText = sqlquery;
                sqlcomm.Connection = sqlconn;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                sda.Fill(dt);

                Console.WriteLine(dt);
                Response.Write(dt);
                System.Diagnostics.Debug.WriteLine(dt);


                GridView2.DataSource = dt;
                GridView2.DataBind();
                sqlconn.Close();
            }
        }

    }
}

//  SELECT * FROM inventory WHERE seedtype = 'harvested' order by quantity desc

/////////////////////////////// TODO //// 
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