using Dance.Store.Api.Middlewares;
using Dance.Store.Application.Configuration;
using Dance.Store.Infrastructure.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Dance.Store.Api.Configuration;

public static class ApplicationBuilderExtension
{
    public static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.AddInfrastructure();
        builder.Services.AddApplication()
            .AddEndpoints()
            .AddSwagger()
            .AddExceptionHandler<HttpGlobalExceptionHandler>();

        return builder;
    }

    private static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Database");
        builder.Services.AddInfrastructure(connectionString);

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