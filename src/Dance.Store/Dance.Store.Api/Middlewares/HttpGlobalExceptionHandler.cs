﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Dance.Store.Application.Exceptions;
using FluentValidation;

namespace Dance.Store.Api.Middlewares;

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
            _ => HandleError(httpContext, exception)
        };

        await task;

        return true;
    }

    private Task HandleNotFoundException(HttpContext httpContext, NotFoundException notFoundException)
    {
        throw new NotImplementedException();
    }

    private Task HandleValidationException(HttpContext context, ValidationException validationException)
    {
        return context.WriteErrorAsync(HttpStatusCode.BadRequest,
            validationException.Errors.Select(x => x.ErrorMessage).ToArray());
    }

    private Task HandleBadRequestException(HttpContext context, BadRequestException badHttpRequestException)
    {
        return context.WriteErrorAsync(HttpStatusCode.BadRequest,
            _environment.IsDevelopment() ? badHttpRequestException.Message : "Bad request");
    }

    private Task HandleError(HttpContext context, Exception exception)
    {
        return context.WriteErrorAsync(HttpStatusCode.InternalServerError,
            _environment.IsDevelopment() ? exception.Message : "An unexpected error occured");
    }
}