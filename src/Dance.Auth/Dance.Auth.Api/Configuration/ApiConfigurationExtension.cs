using Dance.Auth.Api.Middlewares;
using Dance.Auth.BusinessLogic.Configuration;
using Dance.Auth.DataAccess.Configuration;
using Dance.Auth.DataAccess.Context;
using Dance.Auth.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Dance.Auth.Api.Configuration;

public static class ApiConfigurationExtension
{
    public static WebApplicationBuilder ConfigureWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.AddDatabase();
        builder.Services.AddApplicationServices()
            .AddBusinessServices()
            .ConfigureAutoFluentValidation()
            .AddIdentityServices();

        builder.Services.AddExceptionHandler<HttpGlobalExceptionHandler>();

        return builder;
    }

    public static WebApplication ConfigureApplicationPipeline(this WebApplication app)
    {
        app.UseExceptionHandler( _ => { } );

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseHttpsRedirection()
            .UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints => endpoints.MapControllers());

        return app;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddProblemDetails();
        return services.AddEndpointsApiExplorer()
            .AddSwaggerGen(opt =>
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
    }
    
    private static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {  
        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<DanceAuthContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication();
        services.AddAuthorization();

        return services;
    }

    private static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Database");
        builder.Services.ConfigureDatabase(connectionString);
        return builder;
    }
}
