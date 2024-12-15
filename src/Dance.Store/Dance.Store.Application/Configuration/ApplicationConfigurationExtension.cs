using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Dance.Store.Application.UseCases.DanceClass.CreateDanceClass;
using Dance.Store.Application.Validators;
using Confluent.Kafka;
using Dance.Store.Application.UseCases.DanceClass.UpdateDanceClass;
using Dance.Store.Application.Dtos.ResponseDto;
using MediatR;

namespace Dance.Store.Application.Configuration;

public static class ApplicationConfigurationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddFluentValidation()
            .AddServices();
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssemblyContaining<TrainerRequestValidator>()
            .AddFluentValidationAutoValidation();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
            opt.RegisterServicesFromAssemblyContaining<UpdateDanceClassHandler>()
        );

        return services;
    }
}