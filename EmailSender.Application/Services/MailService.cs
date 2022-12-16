using EmailSender.Application.Services.Options;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using EmailSender.Application.Models;

namespace EmailSender.Application.Services
{
    public class MailService
    {
        private readonly MailOptions _mailOptions;
        private readonly SmtpClient _client;

        public MailService(IOptions<MailOptions> mailOptions)
        {
            _mailOptions = mailOptions.Value;
            _client = new SmtpClient();
            _client.Host = "smtp.mail.ru";
            _client.Port = 587;
            _client.EnableSsl = true;
            _client.Credentials = new NetworkCredential(_mailOptions.SenderMailAddress, _mailOptions.SenderMailPassword);
        }

        public async Task SendEmail(MailModel model)
        { 
            await _client.SendMailAsync(new MailMessage(_mailOptions.SenderMailAddress, model.To, null, model.Body));
        }
    }
}
