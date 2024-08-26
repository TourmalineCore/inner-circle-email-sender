﻿using EmailSender.Application.Models;
using EmailSender.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Api.Controllers;

[Route("api/mail")]
public class MailController : Controller
{
    private readonly IEmailSender _mailService;

    public MailController(IEmailSender mailService)
    {
        _mailService = mailService;
    }

    [HttpPost("send-welcome-link")]
    public async Task SendWelcomeLink([FromBody] MailModel model)
    {
        await _mailService.SendEmailAsync(model);
    }

    [HttpPost("send-reset-link")]
    public async Task SendResetLink([FromBody] MailModel model)
    {
        await _mailService.SendEmailAsync(model);
    }

    [HttpPost("send-document")]
    [Consumes("multipart/form-data")]
    public async Task SendDocument([FromForm] MailFileModel model)
    {
        await _mailService.SendEmailFileAsync(model);
    }
}
