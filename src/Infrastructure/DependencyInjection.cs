using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Application.Abstractions.Export;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EnterwellQuizDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("LocalDB")));

        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuizRepository, QuizRepository>();
        
        var container = new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        services.AddSingleton(container);

        services.AddSingleton<IExportServiceProvider, ExportServiceProvider>();
        
        return services;
    }
}
