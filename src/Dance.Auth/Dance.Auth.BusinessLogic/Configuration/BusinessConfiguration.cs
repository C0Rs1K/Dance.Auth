namespace Dance.Auth.Business.Configuration;

public class BusinessConfiguration
{
    public static IServiceCollection ConfigureAutoFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(LoginRequestValidator).Assembly);
        services.AddFluentValidationAutoValidation(); 
        return services; 
    }
}