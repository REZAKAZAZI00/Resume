using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace Resume.Core.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<bool> SendEmailAsync(string to, string subject, string body)
    {
        MailMessage mail = new();
        SmtpClient SmtpServer = new("smtp.c1.liara.email");
        mail.From = new MailAddress("info@blackverse.app", "blackverse");
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;



        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("nice_margulis_nqoc97", "7c9a2472-fdc1-46b0-8994-d2a9c062beb4");
        SmtpServer.EnableSsl = true;


        SmtpServer.Send(mail);

        return true;    
    }
}
