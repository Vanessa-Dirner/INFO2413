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
            lblConfirm.Visible = false;
        }

        protected void InsertSeedPurchase_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-UB0LHNH;Initial Catalog=project;Integrated Security=True"))
            {
                string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand();
                string sqlquery = "INSERT INTO inventory (batch, aquirydate, expirationdate, quantity, seedtype, seedname, plantingtime) values('%'+@batch+'%', '%'+@aquirydate+'%', '%'+@expirationdate+'%', '%'+@quantity+'%', '%'+@seedtype+'%', '%'+@seedname+'%', '%'+@plantingtime+'%');";
                sqlcomm.CommandText = sqlquery;
                sqlcomm.Connection = sqlconn;
                sqlcomm.Parameters.AddWithValue("expirationdate", txtExpirationDate.Text.Trim());
                sqlcomm.Parameters.AddWithValue("quantity", txtQuantity.Text.Trim());
                sqlcomm.Parameters.AddWithValue("seedtype", txtSeedType.Text.Trim());
                sqlcomm.Parameters.AddWithValue("seedname", txtSeedName.Text.Trim());
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                sqlconn.Close();
                lblConfirm.Visible = true;
            }
        }


    }
}