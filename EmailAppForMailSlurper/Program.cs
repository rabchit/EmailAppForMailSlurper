using MimeKit;
using System;
using MailKit.Net.Smtp;


namespace EmailAppForMailSlurper
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            SendEmail();
        }

        static void SendEmail()
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Employee Name", "employee@localhost.com"));
                message.To.Add(new MailboxAddress("Approver Name", "approver@localhost.com"));
                message.Subject = "Approval Request Email";
                message.Body = new TextPart("plain")
                {
                    Text = "This is an approval request test email sent from a C# application."
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("localhost", 2500, false); //2500 the MailKit SMTP Server
                    client.Send(message);
                    client.Disconnect(true);
                }

                Console.WriteLine("Email sent successfully!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: "+ ex);
                Console.ReadLine();
            }
        }

    }
}
