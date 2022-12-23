using EmailSender.Application.Services.Options;
using Microsoft.Extensions.Options;
using EmailSender.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailSender.Application.Services
{
    public class MailService
    {
        private readonly SendGridOptions _mailOptions;
        private readonly SendGridClient _client;

        public MailService(IOptions<SendGridOptions> mailOptions)
        {
            _mailOptions = mailOptions.Value;
            _client = new SendGridClient(_mailOptions.SendGridAPIKey);
        }

        public async Task SendEmail(MailModel model)
        {
            var mail = new SendGridMessage
            {
                From = new EmailAddress(_mailOptions.SenderEmail),
                PlainTextContent = model.Body
            };
            mail.AddTo(new EmailAddress(model.To));
            await _client.SendEmailAsync(mail);
        }
    }
}
