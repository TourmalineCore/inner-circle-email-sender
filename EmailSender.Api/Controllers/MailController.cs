using EmailSender.Application.Models;
using EmailSender.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Api.Controllers
{
    [Route("api/mail")]
    public class MailController : Controller
    {
        private readonly IEmailSender _mailService;
        public MailController(IEmailSender mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send-link")]
        public async Task SendLink([FromBody] MailModel model)
        {
            await _mailService.SendEmailAsync(model);
        }
    }
}
