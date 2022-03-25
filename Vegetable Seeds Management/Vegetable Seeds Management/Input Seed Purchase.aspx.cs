using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Vegetable_Seeds_Management
{
    public partial class Input_Seed_Purchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void InsertSeedPurchase_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-UB0LHNH;Initial Catalog=project;Integrated Security=True"))
            {
                string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand();
                string sqlquery = "INSERT INTO inventory (batch, dateplanted, quantity, seedtype, seedname, plantedby) " +
                "values('B0011', '2022-03-14', '00306', 'Harvested', 'Sunflower', 'YasMan')," +
                "('B0012', '2022-03-22', '00034', 'Bought', 'Tomato', 'GleCar')," +
                "('B0013', '2022-03-10', '00103', 'Bought', 'Apple', 'YasMan')," +
                "('B0014', '2022-03-23', '00035', 'Harvested', 'Grape', 'YasMan'); ";
                    sqlcomm.CommandText = sqlquery;
                sqlcomm.Connection = sqlconn;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                sqlconn.Close();

                lblErrorMessage.Visible = true;
            }
        }


    }
}