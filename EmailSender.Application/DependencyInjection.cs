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
            var mailServiceOptions = configuration.GetSection("GmailOptions");
            services.Configure<GmailOptions>(c => mailServiceOptions.Bind(c));
            services.AddTransient<IEmailSender, SendEmailService>();
            return services;
        }

    }
}