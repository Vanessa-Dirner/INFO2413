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
    public partial class Login_Page : System.Web.UI.Page
    {
        SqlConnection SQLConn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog=Online vegetable seeds management;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void Btn_Login(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = Online vegetable seeds management;Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM staff WHERE userName=@userName AND passwordKey=@passwordKey";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@userName", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@passwordKey", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["userName"] = txtUserName.Text.Trim();
                    Response.Redirect("Admin Dashboard.html");
                }
                else { lblErrorMessage.Visible = true; }
            }
        }
    }
}
