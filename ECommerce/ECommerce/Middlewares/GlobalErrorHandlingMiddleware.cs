using Domain.Exceptions;
using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace ECommerce.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // Response [StatusCode, ErrorMessage]

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
                    await HandleNotFoundEndPointAsync(httpContext);
            }
            catch (Exception exception)
            {
                //throw;
                //log the exception
                _logger.LogError($"Something went wrong {exception}");
                await HandleExceptionAsync(httpContext, exception);
                //handle exception
            }
        }

        private async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            var response = new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                ErrorMessage = $"The End Point {httpContext.Request.Path} Not FOund"
            }.ToString();
            await httpContext.Response.WriteAsync(response);
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            //set content type ==> application/json
            httpContext.Response.ContentType = "application/json";
            var response = new ErrorDetails
            {
                //StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = exception.Message,
            };
            //setdefaultstatuscode => 500
            //httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            //return standard response
            httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                UnAuthorizedException => StatusCodes.Status401Unauthorized,
                ValidationException validationException => HandleValidationEception(validationException, response),
                _ => StatusCodes.Status500InternalServerError
            };

            response.StatusCode = httpContext.Response.StatusCode;
            await httpContext.Response.WriteAsync(response.ToString());
        }

        private int HandleValidationEception(ValidationException validationException, ErrorDetails response)
        {
            response.Errors = validationException.Errors;
            return StatusCodes.Status400BadRequest;
        }
    }
}
