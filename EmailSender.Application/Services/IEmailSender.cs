using EmailSender.Application.Models;
using Microsoft.AspNetCore.Http;

namespace EmailSender.Application.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(MailModel mailModel);
        Task SendEmailFileAsync(MailFileModel mailFileModel);
    }
}
