using Dance.Auth.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dance.Auth.DataAccess.Configuration;

public static class DataConfiguration
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string? connectionString)
    {
        return services.AddDbContext<DanceAuthContext>(dbOptions =>
        {
            dbOptions.UseSqlServer(connectionString, x =>
            {
                x.MigrationsAssembly(typeof(DanceAuthContext).Assembly.FullName);
            });
        });
    }
}