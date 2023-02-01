using EmailSender.Application.Models;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(MailModel mailModel);
        Task<Response> Execute(string apiKey, string message, string email);
    }
}
