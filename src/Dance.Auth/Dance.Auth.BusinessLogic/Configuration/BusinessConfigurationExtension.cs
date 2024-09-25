using Dance.Auth.BusinessLogic.Services;
using Dance.Auth.BusinessLogic.Services.Interfaces;
using Dance.Auth.BusinessLogic.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Dance.Auth.BusinessLogic.Configuration;

public static class BusinessConfigurationExtension
{
    public static IServiceCollection ConfigureAutoFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(LoginRequestValidator).Assembly);
        services.AddFluentValidationAutoValidation(); 
        return services; 
    }

    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IInfoService, InfoService>();
        return services;
    }
}