using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Vegetable_Seeds_Management
{
    public partial class Inventory : System.Web.UI.Page
    {
        SqlConnection SQLConn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog=Online vegetable seeds management;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = Online vegetable seeds management;Integrated Security=True;"))
            {
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("SeedsAddorEdit", sqlCon);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@batch", Convert.ToInt32(hfbatch.Value == "" ? "0" : hfbatch.Value));
                sqlCommand.Parameters.AddWithValue("@quantity", txtQuantity.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@expirationDate", txtExpirationDate.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@plantingTime", txtPlantingTime.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@category", ddlCategory.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@seedType", txtSeedType.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@seedName", txtSeedName.Text.Trim());
                sqlCommand.ExecuteNonQuery();
                Clear();
                lblSuccessMessage.Text = "Seeds Added Successfully";
            }
        }
        void Clear()
        {
            txtQuantity.Text = txtExpirationDate.Text = txtPlantingTime.Text = txtSeedType.Text = txtSeedName.Text =
            hfbatch.Value = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }
    }
}
