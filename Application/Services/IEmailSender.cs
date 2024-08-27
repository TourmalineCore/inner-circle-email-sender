using Application.Models;

namespace Application.Services;

public interface IEmailSender
{
    Task SendEmailAsync(MailModel mailModel);
    Task SendEmailFileAsync(MailFileModel mailFileModel);
}
