using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EnterwellQuizDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("Azure")));
        
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        
        return services;
    }
}
