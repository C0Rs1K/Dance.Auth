namespace Dance.Subscription.Api.Configuration;

public static class ApplicationExtension
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.ConfigureSwagger();
        app.UseExceptionHandler(_ => { })
            .UseRouting()
            .UseHttpsRedirection()
            .UseAuthentication()
            .UseAuthorization()
            .UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
            .UseEndpoints(endpoints => endpoints.MapControllers());

        return app;
    }

    private static WebApplication ConfigureSwagger(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}