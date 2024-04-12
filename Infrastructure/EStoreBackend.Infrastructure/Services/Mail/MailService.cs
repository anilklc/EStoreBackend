using EStoreBackend.Application.Interfaces.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Infrastructure.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool bodyHtml = true)
        {
            await SendMailAsync(to, subject, body, bodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool bodyHtml = true)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = bodyHtml;
            foreach (var to in tos)
            {
                mailMessage.To.Add(to);
            }
            mailMessage.From = new(_configuration["Mail:Username"], _configuration["Mail:Password"], Encoding.UTF8);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtpClient.Host = _configuration["Mail:Host"];
            smtpClient.Port = Convert.ToInt32(_configuration["Mail:Port"]);
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mailMessage);

        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Hello<br>If you have requested a new password, you can renew your password from the link below.<br><strong><a target=\"_blank\" href=\"");
            mail.AppendLine(_configuration["ClientUrl"]);
            mail.AppendLine("/update-password/");
            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine("\">Click to request a new password.</a></strong><br><br><span style=\"font-size:12px;\">NOTE: If this request has not been fulfilled by you, please do not take this e-mail seriously.</span><br>Regards...");

            await SendMailAsync(to, "Password Reset Request", mail.ToString());
        }
    }
}
