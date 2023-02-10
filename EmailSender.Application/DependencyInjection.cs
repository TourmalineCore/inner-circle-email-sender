using EmailSender.Application.Services;
using EmailSender.Application.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailSender.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var switchOptions = configuration.GetSection("SwitchOptions");
            var mailServiceOptions = configuration.GetSection(switchOptions.Value);

            switch (configuration.GetSection("SwitchOptions").Value)
            {
                case "GmailOptions":
                    services.Configure<GmailOptions>(c => mailServiceOptions.Bind(c));
                    services.AddTransient<IEmailSender, SendEmailService>();
                    break;

                case "SendGridOptions":
                    services.Configure<SendGridOptions>(c => mailServiceOptions.Bind(c));
                    services.AddTransient<IEmailSender, SendGridEmailService>();
                    break;

                default:
                    throw new Exception("The SwitchOptions parameter is specified incorrectly");
            }
            
            return services;
        }

    }
}