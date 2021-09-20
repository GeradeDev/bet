using BestShop.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace BetShop.Common.Mailer
{
    public class MailSender : IMailSender
    {
        private MailerSettings _settings { get; set; }

        private MailMessage newMail = new MailMessage();

        public MailSender(IConfiguration config)
        {
            _settings = config.GetOptions<MailerSettings>("MailSettings");
        }

        public void ResetMailer()
        {
            newMail.To.Clear();
            newMail.CC.Clear();
            newMail.Bcc.Clear();
            newMail.Subject = "";
            newMail.Body = "";
            newMail.IsBodyHtml = false;
            newMail.Attachments.Clear();
        }

        public void AddRecipient(string recipient)
        {
            newMail.To.Add(recipient);
        }

        public void AddRecipients(List<string> recipients)
        {
            recipients.ForEach(r => { newMail.To.Add(r); });
        }

        public void AddCCRecipient(string recipient)
        {
            newMail.CC.Add(recipient);
        }

        public void AddCCRecipients(List<string> recipients)
        {
            recipients.ForEach(r => { newMail.CC.Add(r); });
        }

        public void AddSubject(string subject)
        {
            newMail.Subject = subject;
        }

        public void AddBody(string body, bool isHtml = true)
        {
            newMail.Body = body;
            newMail.IsBodyHtml = isHtml;
        }

        public void AddAttachment(string filename)
        {
            throw new NotImplementedException();
        }

        public void AddAttachment(Stream stream, string fileName, string contentType)
        {
            newMail.Attachments.Add(new Attachment(stream, fileName, contentType));
        }

        public string LoadTemplate(string name)
        {
            string emailTemplateHtml = String.Empty;

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{Assembly.GetExecutingAssembly().GetName().Name}.EmailTemplates.{name}"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    emailTemplateHtml = reader.ReadToEnd();
                }
            }

            return emailTemplateHtml;
        }

        public void SendMail()
        {
            SmtpClient SmtpServer = new SmtpClient(_settings.SMTPServer);
            SmtpServer.Port = Int32.Parse(_settings.PortNo);
            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new NetworkCredential(_settings.Username, _settings.Password);

            newMail.Priority = MailPriority.High;
            newMail.From = new MailAddress(_settings.From);

            SmtpServer.Send(newMail);
        }
    }
}