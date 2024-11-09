using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry.Serdes;
using Dance.Store.Domain.Entities;
using Dance.Store.Domain.Interfaces;
using Dance.Store.Infrastructure.Context;
using Dance.Store.Infrastructure.Kafka;
using Dance.Store.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dance.Store.Infrastructure.Configuration;

public static class InfrastructureConfigurationExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, ConsumerConfig config)
    {
        return services.ConfigureDatabase(connectionString)
            .AddRepositories();
        //.ConfigureKafka(config);
    }

    private static IServiceCollection ConfigureKafka(this IServiceCollection services, ConsumerConfig config)
    {
        var consumer = new ConsumerBuilder<string, Student>(config)
            .SetValueDeserializer(
                new JsonDeserializer<Student>().AsSyncOverAsync()
                )
            .Build();
        services.AddSingleton(consumer);
        services.AddHostedService<KafkaConsumer>();

        return services;
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