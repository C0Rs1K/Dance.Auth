using Dance.Subscription.Domain.Interfaces;
using Dance.Subscription.infrastructure.Options;
using Dance.Subscription.infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Dance.Subscription.infrastructure.Configuration;

public static class InfrastructureConfigurationExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, MongoDbOptions options)
    {
        return services.ConfigureDatabase(options)
            .AddRepositories();
    }

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services, MongoDbOptions options)
    {
        var mongoClient = new MongoClient(options.ConnectionString);
        var database = mongoClient.GetDatabase(options.DatabaseName);
        services.AddSingleton(database);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        services.AddScoped<IStudentSubscriptionRepository, StudentSubscriptionRepository>();

        return services;
    }
}