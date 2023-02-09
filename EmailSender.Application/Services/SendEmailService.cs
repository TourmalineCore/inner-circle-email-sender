using EmailSender.Application.Models;
using EmailSender.Application.Services.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services
{
    public class SendEmailService : IEmailSender
    {
        private readonly GmailOptions _mailOptions;
        private readonly SmtpClient _client;
        public SendEmailService(IOptions<GmailOptions> mailOptions)
        {
            _mailOptions = mailOptions.Value;
            _client = new SmtpClient(_mailOptions.Host, int.Parse(_mailOptions.Port));
            _client.EnableSsl = true;
            _client.Credentials = new System.Net.NetworkCredential(_mailOptions.FromEmail, _mailOptions.FromPassword);
            _client.DeliveryMethod = SmtpDeliveryMethod.Network;
            _client.UseDefaultCredentials = false;

        }
        public async Task SendEmailAsync(MailModel mailModel)
        {
            var email = new MailMessage();
            email.From = new MailAddress(_mailOptions.FromEmail);
            email.To.Add(mailModel.To);
            email.Subject = mailModel.Subject;
            email.Body = mailModel.Body;

            await _client.SendMailAsync(email);
        }
    }
}
