using Dance.Subscription.Application.Commands.Student;
using Dance.Subscription.Application.Validator;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Dance.Subscription.Application.Handlers.Commands;
using Dance.Subscription.Application.Handlers.Commands.StudentSubscription;

namespace Dance.Subscription.Application.Configuration;

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
        return services.AddValidatorsFromAssemblyContaining<StudentRequestDtoValidator>()
            .AddFluentValidationAutoValidation();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
            opt.RegisterServicesFromAssemblyContaining<DeleteExpiredSubscriptionHandler>()
        );

        return services;
    }
}