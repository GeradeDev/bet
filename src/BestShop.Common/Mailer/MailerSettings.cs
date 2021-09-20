using System;
using System.Collections.Generic;
using System.Text;

namespace BetShop.Common.Mailer
{
    public class MailerSettings
    {
        public string SMTPServer { get; set; }
        public string From { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PortNo { get; set; }
    }
}
