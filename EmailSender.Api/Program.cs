using EmailSender.Application.Services.Options;
using EmailSender.Application.Services;
using System.Reflection;

const string appEnvironmentVariableName = "ASPNETCORE_ENVIRONMENT";
const string debugEnvironmentName = "Debug";
const string developmentEnvironmentName = "Development";

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

if (Environment.GetEnvironmentVariable(appEnvironmentVariableName) == debugEnvironmentName
|| Environment.GetEnvironmentVariable(appEnvironmentVariableName) == developmentEnvironmentName)
{
    builder.Services.Configure<GoogleSmtpOptions>(opt => configuration.GetSection(nameof(GoogleSmtpOptions)));
    builder.Services.AddTransient<IEmailSender, GmailSender>();
}


var app = builder.Build();

if (app.Environment.IsEnvironment("Debug"))
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