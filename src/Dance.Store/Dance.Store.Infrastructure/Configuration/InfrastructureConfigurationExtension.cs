using Dance.Store.Domain.Interfaces;
using Dance.Store.Infrastructure.Context;
using Dance.Store.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dance.Store.Infrastructure.Configuration;

public static class InfrastructureConfigurationExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        return services.ConfigureDatabase(connectionString)
            .AddRepositories();
    }

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<DanceDbContext>(dbOptions =>
        {
            dbOptions.UseSqlServer(connectionString, x =>
            {
                x.MigrationsAssembly(typeof(DanceDbContext).Assembly.FullName);
            });
        });
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDanceClassRepository,DanceClassRepository>();
        services.AddScoped<IRegistrationStatusRepository, RegistrationStatusRepository>();
        services.AddScoped<IStudentRegistrationRepository, StudentRegistrationRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ITrainerRepository, TrainerRepository>();

        return services;
    }
}