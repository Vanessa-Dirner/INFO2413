using System;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
public class expirynotify
{
	public expirynotify()
	{
        string NULL = null;

        using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ASPLogin;Integrated Security=True;"))

            // Get seeds expiring in 1 year or less
            sqlCon.Open();
		string expiringSeeds = "SELECT * FROM inventory WHERE expirationdate >= dateadd(year, +1, getdate())";
        // notify
		if (expiringSeeds != NULL)
        {
            Console.WriteLine("The following seeds are expiring within 1 year: ");
            Console.WriteLine("expiringSeeds");
        }

		// if seeds have expired, move to expired table
		string expiredSeeds = "SELECT * FROM inventory WHERE expirationdate < getdate()"

        if (expiredSeeds != NULL)
        {
			string moveExpiredSeeds = "BEGIN TRANSACTION; INSERT INTO waste; SELECT * FROM inventory WHERE expirationdate < getdate(); DELETE FROM inventorywhere expirationdate < getdate(); COMMIT "
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue(moveExpiredSeeds )
        }

        // email notification to administrator
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("SampleFarmSeedsCo@gmail.com", "SampleFarmSeedsCo99"),
            EnableSsl = true,
        };

        smtpClient.Send("SampleFarmSeedsCo@gmail.com", "sample@gmail.com", "Notification:ExpiringSeeds", "List of expiredSeeds");
    }
}


    