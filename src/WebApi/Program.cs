using Serilog;
using Application;
using Infrastructure;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseGlobalExceptionHandling();

app.UseHttpsRedirection();

app.Run();
