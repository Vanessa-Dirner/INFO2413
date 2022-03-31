using System;
using MailKit.Net.Smtp;
using MimeKit;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Vegetable_Seeds_Management
{
    public class AutomaticEmails
    {
        static void Main(string[] args)
        {

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                // CHeck for seeds under 500g
                string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand();
                string WastedSeeds = "SELECT * FROM waste WHERE  quantity > 500";
                sqlcomm.CommandText = WastedSeeds;
                sqlcomm.Connection = sqlconn;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                sda.Fill(dt);

                // notify
                if (!string.IsNullOrEmpty(WastedSeeds))
                {
                    string reportmsg = "The following seed quantities are less than 500g";
                    SendEmail(reportmsg, dt);
                }

                // Get seeds expiring in 1 year or less
                sqlCon.Open();
                string expiringSeeds = "SELECT * FROM inventory WHERE expirationdate >= dateadd(year, +1, getdate())";
                // notify
                if (string.IsNullOrEmpty(expiringSeeds))
                {
                    MoveExpiredSeeds();
                    string reportmsg = "The following seeds are expiring in 1 year or less:"
                    SendEmail(reportmsg, dt);
                }
            }

            // use this method to send emails
            void SendEmail(string reportmsg, DataTable query)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Farmer Seeds", "samplefarmseedsco@gmail.com"));
                message.To.Add(new MailboxAddress("Farmer Seeds", "samplefarmseedsco@gmail.com"));
                message.Subject = "Vegetable Seed Managment System";

                message.Body = new TextPart("plain")
                {
                    Text = @"Dear Systems Administrator,
                Please see the following report(s):

                -- Sent via Systems Managment System
                "
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("samplefarmseedsco@gmail.com", "nqlgvacxneplndbt");

                    client.Send(message);
                    client.Disconnect(true);
                }
            }

            void MoveExpiredSeeds()
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
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
                        }
                    }
                }
            }
        }
    }
}
