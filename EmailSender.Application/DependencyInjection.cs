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

            if (switchOptions.Value.Equals("GmailOptions"))
            {
                
                services.Configure<GmailOptions>(c => mailServiceOptions.Bind(c));
                services.AddTransient<IEmailSender, SendEmailService>();
            }
            else
            {
                services.Configure<SendGridOptions>(c => mailServiceOptions.Bind(c));
                services.AddTransient<IEmailSender, SendGridEmailService>();
            }
            
            return services;
        }

    }
}