using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Interfaces.Mail
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string body, bool bodyHtml = true);
        Task SendMailAsync(string[] tos, string subject, string body, bool bodyHtml = true);
        Task SendPasswordResetMailAsync(string to, string userId, string resetToken);
    }
}
