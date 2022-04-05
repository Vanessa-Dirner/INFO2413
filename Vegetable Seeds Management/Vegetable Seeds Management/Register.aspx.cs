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
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection SQLConn = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
                lblErrorMessage.Text = "Please fill Mandatory Fields";
            else if (txtPassword.Text != txtConfirmPassword.Text)
                lblErrorMessage.Text = "Password do not match";
            else
            {

                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    sqlCon.Open();
                    SqlCommand sqlCommand = new SqlCommand("StaffAddorEdit", sqlCon);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@userid", Convert.ToInt32(hfuserid.Value == "" ? "0" : hfuserid.Value));
                    sqlCommand.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@jobRole", ddlJobRole.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@eMail", txtEmail.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@userName", txtUsername.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@passwordKey", txtPassword.Text.Trim());
                    sqlCommand.ExecuteNonQuery();
                    Clear();
                    lblSuccessMessage.Text = "Submitted Successfully";
                }
            }
        }
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtEmail.Text = txtUsername.Text = txtPassword.Text =
            txtConfirmPassword.Text = ""; hfuserid.Value = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }
    }
}
