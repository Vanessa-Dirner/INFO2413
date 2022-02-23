using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Online_Vegetable_Seed_Management_1_
{
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection SQLConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ASPLogin;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ASPLogin;Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM useraccount WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Dashboard.aspx");

                }
                else { lblErrorMessage.Visible = true; }
            }

        }
    }
}
