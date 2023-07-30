using WebApi.Abstractions;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace WebApi.Extensions;

public static class WebAPIExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        var cs = builder.Configuration.GetConnectionString("Azure");
        builder.Services.AddDbContext<EnterwellQuizDbContext>(opt => opt.UseSqlServer(cs));
    }

    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition))
                && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.RegisterEndpoints(app);
        }
    }

    public static void UseGlobalExceptionHandling(this WebApplication app)
    {
        app.Use(async (ctx, next) =>
        {
            try
            {
                await next();
            }
            catch (Exception)
            {
                ctx.Response.StatusCode = 500;
                await ctx.Response.WriteAsync("An error occured.");
            }
        });
    }
}
