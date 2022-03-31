using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace Vegetable_Seeds_Management
{

    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (Session["Userid"] == null) Response.Redirect("Login Page.aspx");
        }



        protected void WastedSeedsReport_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
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
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
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
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
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

        protected void WastedSeeds(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                //Get seeds wasted in last year
                string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand();
                string WastedSeeds = "SELECT * FROM waste order by quantity desc";
                sqlcomm.CommandText = WastedSeeds;
                sqlcomm.Connection = sqlconn;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                sda.Fill(dt);


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

            void MoveExpiredSeeds()
            {

                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    // if seeds have expired, move to expired table
                    string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(mainconn);
                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand();
                    string expiredSeeds = "SELECT * FROM inventory WHERE expirationdate < getdate()";
                    sqlcomm.CommandText = expiredSeeds;
                    sqlcomm.Connection = sqlconn;
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                    sda.Fill(dt);


                    if (string.IsNullOrEmpty(expiredSeeds))
                    {
                        string moveExpiredSeeds = "BEGIN TRANSACTION; INSERT INTO waste; SELECT * FROM inventory WHERE expirationdate < getdate(); DELETE FROM inventorywhere expirationdate < getdate(); COMMIT ";
                        sqlcomm.CommandText = moveExpiredSeeds;
                        sqlcomm.Connection = sqlconn;
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter sda1 = new SqlDataAdapter(sqlcomm);
                        sda.Fill(dt);

                        //SqlCommand sqlCmd = new SqlCommand(sqlCon);
                        //sqlCmd.Parameters.AddWithValue(moveExpiredSeeds)
                    }

                    // email notification to administrator
                }

                void ExpiringSeeds()
                {

                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                    {

                        // Get seeds expiring in 1 year or less
                        sqlCon.Open();
                        string expiringSeeds = "SELECT * FROM inventory WHERE expirationdate >= dateadd(year, +1, getdate())";
                        // notify
                        if (string.IsNullOrEmpty(expiringSeeds))
                        {
                            Console.WriteLine("The following seeds are expiring within 1 year: ");
                            Console.WriteLine("expiringSeeds");
                        }

                    }
                }

                MoveExpiredSeeds();
                ExpiringSeeds();




            }
        }

    }
}




       

         


