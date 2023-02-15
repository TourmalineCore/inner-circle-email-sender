using EmailSender.Application.Models;

namespace EmailSender.Application.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(MailModel mailModel);
    }
}
