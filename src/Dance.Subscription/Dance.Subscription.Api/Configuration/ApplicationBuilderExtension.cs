using Dance.Subscription.Api.Middleware;
using Dance.Subscription.Application.Configuration;
using Dance.Subscription.infrastructure.Configuration;
using Dance.Subscription.infrastructure.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Dance.Subscription.Api.Configuration;

public static class ApplicationBuilderExtension
{
    public static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.AddInfrastructure();
        builder.Services.AddApplication()
            .AddEndpoints()
            .AddSwagger()
            .AddExceptionHandler<HttpGlobalExceptionHandler>(); ;

        return builder;
    }

    private static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        var options = builder.Configuration
            .GetSection("MongoDbOptions")
            .Get<MongoDbOptions>();
        builder.Services.AddInfrastructure(options);

        return builder;
    }

    private static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            opt.OperationFilter<SecurityRequirementsOperationFilter>();
            opt.DescribeAllParametersInCamelCase();
        });

        return services;
    }
}