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
            if (Session["Userid"] == null) Response.Redirect("Login Page.aspx");
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


            }
        }

       

         


