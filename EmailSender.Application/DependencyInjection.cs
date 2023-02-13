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
            const string appEnvironmentVariableName = "ASPNETCORE_ENVIRONMENT";
            const string debugEnvironmentName = "Debug";
            const string developmentEnvironmentName = "Development";

            if (Environment.GetEnvironmentVariable(appEnvironmentVariableName) == debugEnvironmentName 
            || Environment.GetEnvironmentVariable(appEnvironmentVariableName) == developmentEnvironmentName) 
            {
                services.Configure<GoogleSmtpOptions>(opt => configuration.GetSection(nameof(GoogleSmtpOptions)));
                services.AddTransient<IEmailSender, GmailSender>();
            }
            
            return services;
        }

    }
}