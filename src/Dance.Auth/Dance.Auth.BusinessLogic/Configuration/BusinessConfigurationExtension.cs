using Confluent.Kafka;
using Dance.Auth.BusinessLogic.Dtos.ResponseDto;
using Dance.Auth.BusinessLogic.Services;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Dance.Auth.BusinessLogic.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Dance.Auth.BusinessLogic.Configuration;

public static class BusinessConfigurationExtension
{
    public static IServiceCollection ConfigureBusinessLogicLayer(this IServiceCollection services,
        ProducerConfig config)
    {
        services.ConfigureAutoFluentValidation()
            .AddBusinessServices();
            //.ConfigureKafka(config);

        return services;
    }

    private static IServiceCollection ConfigureAutoFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(LoginRequestValidator).Assembly);
        services.AddFluentValidationAutoValidation(); 

        return services; 
    }

    private static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IInfoService, InfoService>();
        services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IProduceService, ProduceService>();

        return services;
    }

    private static IServiceCollection ConfigureKafka(this IServiceCollection services,
        ProducerConfig config)
    {
        var producer = new ProducerBuilder<string, UserResponseDto>(config)
            .SetValueSerializer(new UserJsonSerializer())
            .Build();
        services.AddSingleton(producer);

        return services;
    }
}