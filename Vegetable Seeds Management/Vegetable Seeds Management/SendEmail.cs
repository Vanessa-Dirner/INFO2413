using System;
using MailKit.Net.Smtp;
using MimeKit;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Vegetable_Seeds_Management
{
    public class SendEmail
    {
        public static void Main(string[] args)
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

                        using (SqlConnection sqlConn = new SqlConnection(@"Data Source=desktop-ub0lhnh;Initial Catalog=project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
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