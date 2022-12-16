using EmailSender.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configuration = builder.Configuration;

builder.Services.AddApplication(configuration);

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers();});


app.Run();
