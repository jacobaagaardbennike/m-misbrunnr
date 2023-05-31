using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailLib
{
    public class EmailService : IEmailSender
    {

        public string SmtpHost { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpUser { get; set; }

        public string SmtpPass { get; set; }

        public EmailService(string smtpHost, int smtpPort, string smtpUser, string smtpPass)
        {
            this.SmtpHost = smtpHost;
            this.SmtpPort = smtpPort;
            this.SmtpUser = smtpUser;
            this.SmtpPass = smtpPass;
        }

        public void SendEmail(MailMessage msg)
        {

            try
            {
                using (SmtpClient client = new SmtpClient()
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(SmtpUser, SmtpPass),
                    Port = SmtpPort,
                    Host = SmtpHost,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true
                })
                {
                    client.Send(msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " | " + ex.InnerException);
            }
        }

        public MailMessage BuildMailMessage(string from, string to, string subject, string body)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(to));
            msg.From = new MailAddress(from);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;
            return msg;
        }
	}
}
