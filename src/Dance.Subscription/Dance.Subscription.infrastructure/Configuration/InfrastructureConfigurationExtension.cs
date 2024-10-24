using Dance.Subscription.Domain.Interfaces;
using Dance.Subscription.infrastructure.Options;
using Dance.Subscription.infrastructure.Repositories;
using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
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
        services.ConfigureHangfire(mongoClient)
            .AddSingleton(database);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        services.AddScoped<IStudentSubscriptionRepository, StudentSubscriptionRepository>();

        return services;
    }

    private static IServiceCollection ConfigureHangfire(this IServiceCollection services, MongoClient mongoClient)
    {
        services.AddHangfire(configuration =>
            configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMongoStorage(mongoClient, "jobs", new MongoStorageOptions
                {
                    MigrationOptions = new MongoMigrationOptions
                    {
                        MigrationStrategy = new MigrateMongoMigrationStrategy(),
                        BackupStrategy = new CollectionMongoBackupStrategy()
                    },
                    Prefix = "hangfire.mongo",
                    CheckConnection = true,
                    CheckQueuedJobsStrategy = CheckQueuedJobsStrategy.TailNotificationsCollection
                })
        );
        services.AddHangfireServer();

        return services;
    }
}