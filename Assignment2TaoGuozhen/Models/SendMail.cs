using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Assignment2TaoGuozhen.Models
{
    public class SendMail : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("supercoolcoolya@gmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = email + htmlMessage;
                mailMessage.IsBodyHtml = true; 
                mailMessage.To.Add(new MailAddress(email));
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = "supercoolcoolya@gmail.com";
                networkCredential.Password = "Koala19840920";
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 465;
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
