using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailLib
{
    public interface IEmailSender
    {
        string SmtpHost { get; set; }
        int SmtpPort { get; set; }
        string SmtpUser { get; set; }
        string SmtpPass { get; set; }
        void SendEmail(MailMessage msg);
        MailMessage BuildMailMessage(string from, string to, string subject, string body);
    }
}
