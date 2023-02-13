using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services.Options
{
    public class GoogleSmtpOptions
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string FromEmail { get; set; }
        public string FromPassword { get; set; }

    }
}