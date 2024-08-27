using System.Reflection;
using Api;
using Application.Services;
using Application.Services.Options;

const string appEnvironmentVariableName = "ASPNETCORE_ENVIRONMENT";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;

    var reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);

    config.AddJsonFile("appsettings.json", true, reloadOnChange)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, reloadOnChange)
        .AddJsonFile("appsettings.Active.json", true, reloadOnChange);

    if (env.IsDevelopment() && !string.IsNullOrEmpty(env.ApplicationName))
    {
        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));

        config.AddUserSecrets(appAssembly, true);
    }

    config.AddEnvironmentVariables();

    if (args != null)
    {
        config.AddCommandLine(args);
    }
});

var environmentName = Environment.GetEnvironmentVariable(appEnvironmentVariableName);

if (environmentName == EnvironmentVariable.Debug.ToString() || environmentName == EnvironmentVariable.Development.ToString())
{
    builder.Services.Configure<MailSmtpOptions>(configuration.GetSection(nameof(MailSmtpOptions)));
    builder.Services.AddTransient<IEmailSender, GmailSender>();
}

var app = builder.Build();

if (app.Environment.IsEnvironment(EnvironmentVariable.Debug.ToString()))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(
    corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyHeader()
    .SetIsOriginAllowed(host => true)
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.UseEndpoints(endpoints => { endpoints.MapControllers();});


app.Run();
