﻿using ExemploCqrs.Aplicacao.Excecoes;
using FluentValidation;
using System.Collections.Immutable;
using System.Text.Json;

namespace ExemploCqrs.Middlewares
{
    public sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new DefaultErrorResponse
            {
                Status = statusCode,
                Detail = exception.Message,
                Errors = GetErrors(exception)
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static IReadOnlyDictionary<string, string>? GetErrors(Exception exception)
        {
            IReadOnlyDictionary<string, string>? errors = null;
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors.ToDictionary(x => x.ErrorCode, x => x.ErrorMessage).ToImmutableDictionary();
            }
            return errors;
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                GeneralBadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
