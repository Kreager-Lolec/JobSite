using MailKit.Net.Smtp;
using MimeKit;
using System.Net;

namespace JobSite
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Адміністрація сайта", "zhuranskyifop@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (SmtpClient client = new())
            {
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential(address, password);
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("zhuranskyifop@gmail.com", "cswvfwljdrnnawye");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
