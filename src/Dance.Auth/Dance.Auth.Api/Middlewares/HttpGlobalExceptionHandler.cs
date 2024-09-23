using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Dance.API.ActionFilters.Extensions;
using Dance.Auth.Business.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Dance.Auth.Api.Middlewares;

public class HttpGlobalExceptionHandler(IHostEnvironment environment) : IExceptionHandler
{
    private readonly IHostEnvironment _environment = environment ?? throw new ArgumentNullException(nameof(environment));

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var task = exception switch
        {
            ValidationException validationException => HandleValidationException(httpContext, validationException),
            BadRequestException badRequestException => HandleBadRequestException(httpContext, badRequestException),
            NotFoundException notFoundException => HandleNotFoundException(httpContext, notFoundException),
            UnauthorizedException unauthorizedException => HandleUnauthorizedException(httpContext, unauthorizedException)
            _ => HandleError(httpContext, exception),
        };

        await task;

        return true;
    }

    private Task HandleValidationException(HttpContext context, ValidationException validationException)
    {
        return context.WriteErrorAsync(HttpStatusCode.BadRequest,
            validationException.Errors.Select(x => x.ErrorMessage).ToArray());
    }

    private Task HandleNotFoundException(HttpContext context, NotFoundException notFoundException)
    {
        return context.WriteErrorAsync(HttpStatusCode.NotFound,
            _environment.IsDevelopment() ? notFoundException.Message : "Resource not found");
    }

    private Task HandleBadRequestException(HttpContext context, BadRequestException badHttpRequestException)
    {
        return context.WriteErrorAsync(HttpStatusCode.BadRequest,
            _environment.IsDevelopment() ? badHttpRequestException.Message : "Bad request");
    }

    private Task HandleUnauthorizedException(HttpContext context, UnauthorizedException unauthorizedException)
    {
        return context.WriteErrorAsync(HttpStatusCode.Unauthorized,
            _environment.IsDevelopment() ? unauthorizedException.Message : "Unauthorized")
    }

    private Task HandleError(HttpContext context, Exception exception)
    {
        return context.WriteErrorAsync(HttpStatusCode.InternalServerError,
            _environment.IsDevelopment() ? exception.Message : "An unexpected error occured");
    }
}