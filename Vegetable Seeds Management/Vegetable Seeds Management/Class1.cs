using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

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
}