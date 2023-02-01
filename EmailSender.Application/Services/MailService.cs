using EmailSender.Application.Services.Options;
using Microsoft.Extensions.Options;
using EmailSender.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailSender.Application.Services
{
    public class MailService : IEmailSender
    {
        private readonly SendGridOptions _mailOptions;

        public MailService(IOptions<SendGridOptions> mailOptions)
        {
            _mailOptions = mailOptions.Value;
        }

        public async Task SendEmailAsync(MailModel mailModel)
        {
            if (string.IsNullOrEmpty(_mailOptions.SendGridAPIKey))
            {
                throw new Exception("Null SendGridKey");
            }

            await Execute(_mailOptions.SendGridAPIKey, mailModel.Body, mailModel.To);
        }

        public async Task<Response> Execute(string apiKey, string message, string email)
        {
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_mailOptions.SenderEmail, _mailOptions.SenderName),
                Subject = "Данные для входа",
                PlainTextContent = message,
                HtmlContent = $"<div>{message}</div>",
            };

            msg.AddTo(email);

            return await client.SendEmailAsync(msg);
        }
    }
}
