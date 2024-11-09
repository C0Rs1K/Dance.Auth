using System.Net;
using System.Text.Json;

namespace Dance.Subscription.Api.Middleware;

public static class HttpContextExtensions
{
    public static Task WriteErrorAsync(this HttpContext httpContext, HttpStatusCode statusCode, params string[] errors)
    {
        var text = JsonSerializer.Serialize(new
        {
            Errors = errors
        });

        httpContext.Response.StatusCode = (int)statusCode;
        httpContext.Response.ContentType = "application/json";

        return httpContext.Response.WriteAsync(text);
    }
}
