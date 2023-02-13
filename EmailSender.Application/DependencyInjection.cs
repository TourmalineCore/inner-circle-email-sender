﻿using EmailSender.Application.Services;
using EmailSender.Application.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailSender.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            switch (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
            {
                case "Debug":
                    services.Configure<GmailOptions>(c => configuration.GetSection("GmailOptions").Bind(c));
                    services.AddTransient<IEmailSender, SendEmailService>();
                    break;

                case "Development":
                    services.Configure<GmailOptions>(c => configuration.GetSection("GmailOptions").Bind(c));
                    services.AddTransient<IEmailSender, SendEmailService>();
                    break;
            }
            
            return services;
        }

    }
}