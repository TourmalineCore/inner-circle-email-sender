using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services.Options
{
    public class SendGridOptions
    {
        public string SendGridAPIKey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
    }
}
