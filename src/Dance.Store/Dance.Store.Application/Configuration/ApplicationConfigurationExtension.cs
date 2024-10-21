using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Dance.Store.Application.UseCases.DanceClass.CreateDanceClass;
using Dance.Store.Application.Validators;
using Confluent.Kafka;

namespace Dance.Store.Application.Configuration;

public static class ApplicationConfigurationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddFluentValidation()
            .AddServices()
            .ConfigureKafka();
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssemblyContaining<TrainerRequestValidator>()
            .AddFluentValidationAutoValidation();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
            opt.RegisterServicesFromAssemblyContaining<CreateDanceClassCommand>()
        );

        return services;
    }

    private static IServiceCollection ConfigureKafka(this IServiceCollection services)
    {
        services.AddSingleton(provider =>
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "first-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            return new ConsumerBuilder<string, string>(config).Build();
        });

        return services;
    }
}