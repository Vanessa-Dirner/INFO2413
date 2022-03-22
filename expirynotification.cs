using System;

public class expirynotify
{
	public expirynotify()
	{
        // Get seeds expiring in 1 year or less
        sqlCon.Open();
		string expiringSeeds = "SELECT * FROM inventory WHERE expirationdate >= dateadd(year, +1, getdate())";
        // notify
		if (expiringSeeds != NULL)
        {
			Write-line "The following seeds are expiring within 1 year: "
			Write-line	expiringSeeds
        }

		// if seeds have expired, move to expired table
		string expiredSeeds = "SELECT * FROM inventory WHERE expirationdate < getdate()"
		if (expiredSeeds != NULL)
        {
			string moveExpiredSeeds = "" +
                "BEGIN TRANSACTION" +
                "INSERT INTO waste" +
                "SELECT * FROM inventory " +
                "WHERE expirationdate < getdate();" +
                "DELETE FROM inventory" +
                "where expirationdate < getdate();" +
                "COMMIT"
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


    