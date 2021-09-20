using System;
using System.Collections.Generic;
using System.Text;

namespace BetShop.Common.Mailer
{
    public interface IMailSender
    {
        void AddRecipient(string recipient);

        void AddRecipients(List<string> recipient);

        void AddCCRecipient(string recipient);

        void AddCCRecipients(List<string> recipient);

        void AddSubject(string subject);

        void AddBody(string body, bool isHtml);

        void AddAttachment(string body);

        string LoadTemplate(string name);

        void SendMail();
    }
}
