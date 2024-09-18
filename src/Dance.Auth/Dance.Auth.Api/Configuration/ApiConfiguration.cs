using Dance.Auth.Data.Configuration;

namespace Dance.Auth.Api.Configuration;

public static class ApiConfiguration
{
    public static WebApplicationBuilder ConfigureWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.AddDatabase();
        builder.Services.AddApplicationServices()
            .AddIdentityServices();

        return builder;
    }

    public static WebApplication ConfigureApplicationPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection()
            .UseRouting()
            .UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
            .UseAuthorization()
            .UseAuthentication()
            .UseEndpoints(endpoints => endpoints.MapControllers()); ; ;

        return app;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddControllers();
        return services.AddEndpointsApiExplorer()
            .AddSwaggerGen();
    }
    
    private static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<DanceAuthContext>()
            .AddDefaultTokenProviders();
    }

    private static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Database");
        builder.Services.ConfigureDatabase(connectionString);
        return builder;
    }
}
