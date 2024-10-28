using Application.Models;
using Application.Services.Options;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace Application.Services;

public class GmailSender : IEmailSender
{
    private readonly MailSmtpOptions _mailOptions;
    private readonly SmtpClient _client;

    public GmailSender(IOptions<MailSmtpOptions> mailOptions)
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
        Console.WriteLine("*** Welcome mail was sent!");
    }

    public async Task SendEmailFileAsync(MailFileModel mailFileModel)
    {
        var email = new MailMessage();

        await using var stream = mailFileModel.File.OpenReadStream();

        var attachment = new Attachment(stream, mailFileModel.File.FileName);
        email.Attachments.Add(attachment);

        email.From = new MailAddress(_mailOptions.FromEmail);
        email.To.Add(mailFileModel.To);
        email.Subject = mailFileModel.Subject;
        email.Body = mailFileModel.Body;

        await _client.SendMailAsync(email);
    }
}
