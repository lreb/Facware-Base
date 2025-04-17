using System.Net;
using Microsoft.AspNetCore.Mvc;
using NetCoreBase.Domain.Common;

namespace NetCoreBase.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (OperationCanceledException ex)
            {
                // Handle the cancellation
                // You can log the cancellation or take any other action you need
                throw new Exception("Operation was canceled.", ex);
            }
            catch (Exception ex)
            {
                // Log the exception with relevant details
                _logger.LogError(ex, "An unhandled exception occurred. Request: {Method} {Path}, StatusCode: {StatusCode}, Message: {Message}",
                    context.Request.Method, context.Request.Path, StatusCodes.Status500InternalServerError, ex.Message);

                // Set the response details
                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                               
                await HandleExceptionAsync(context, ex);
            }
            finally
            {
                // Log the request and response details
                _logger.LogInformation("Request: {Method} {Path}, StatusCode: {StatusCode}",
                    context.Request.Method, context.Request.Path, context.Response.StatusCode);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/problem+json";
            var problemDetails = new ProblemDetails
            {
                Instance = context.Request.Path,
                Detail = "An error occurred while processing your request."
            };

            var response = new OperationResponse<string>().FailOperation
                   (
                      "No data",
                      StatusCodes.Status500InternalServerError,
                      ex.Message,
                      $"InnerException: {ex.InnerException}"
                   );

            _logger.LogError(ex, "Error occurred: {Message}, Status: {Status}", ex.Message, problemDetails.Status);
            context.Response.StatusCode = response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
