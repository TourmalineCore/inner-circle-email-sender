using Microsoft.AspNetCore.Http;

namespace EmailSender.Application.Models
{
    public class MailPayslipsModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public IFormFile File { get; set; }
    }
}
