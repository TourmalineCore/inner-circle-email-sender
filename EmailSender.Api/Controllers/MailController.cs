using EmailSender.Application.Models;
using EmailSender.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Api.Controllers
{
    [Route("api/mail")]
    public class MailController : Controller
    {
        private readonly MailService _mailService;
        public MailController(MailService mailService)
        {
            _mailService = mailService;
        }
        [HttpPost("send-link")]
        public Task SendLink([FromBody] MailModel model)
        {
            return _mailService.SendEmail(model);
        }
    }
}
