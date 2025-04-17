using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreBase.Domain.Common;

namespace NetCoreBase.API.ActionFilter
{
    public class StatusCodeWrapperFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // No-op before action
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var result = new OperationResponse<object>()
                                    .FailOperation(default, StatusCodes.Status400BadRequest, "Validation failed", string.Join("; ", errors));
                context.Result = new ObjectResult(result)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null || context.Result is ObjectResult { Value: OperationResponse<object> })
                return; // Skip if exception or already wrapped

            if (context.Result is ObjectResult objectResult)
            {
                var statusCode = objectResult.StatusCode ?? (int)HttpStatusCode.OK;

                if (statusCode >= 100 && statusCode <= 299)
                {

                    //return or.StatusCode(httpCode,
                    //                new OperationResponse<T>()
                    //                    .SuccessOperation(data, httpCode,
                    //                    message)
                    //            );
                    context.Result = new ObjectResult(new OperationResponse<object>()
                                    .SuccessOperation(objectResult.Value, statusCode
                                    ))
                    {
                        StatusCode = statusCode
                    };
                }
                else if (statusCode >= 300 && statusCode <= 499)
                {
                    //return StatusCode(httpCode,
                    //                new OperationResponse<T>()
                    //                    .WarningOperation(data, httpCode,
                    //                    message)
                    //            );
                    context.Result = new ObjectResult(objectResult.Value)
                    {
                        StatusCode = statusCode
                    };
                }
                else
                {
                    context.Result = new ObjectResult(new OperationResponse<object>()
                                    .FailOperation(objectResult.Value, statusCode
                                    ))
                    {
                        StatusCode = statusCode
                    };
                }
            }
            else if (context.Result is StatusCodeResult statusCodeResult)
            {
                var statusCode = statusCodeResult.StatusCode;
                var response = statusCode >= 400
                    ? new OperationResponse<object>().FailOperation(default, statusCode)
                    : new OperationResponse<object>().SuccessOperation(default, statusCode, $"Status code {statusCode} returned.");
                context.Result = new ObjectResult(response)
                {
                    StatusCode = statusCode
                };
            }
            else if (context.Result is NotFoundResult)
            {
                var notFound = new OperationResponse<object>().WarningOperation(default, StatusCodes.Status404NotFound,
                    "Resource not found",
                    $"The requested resource at {context.HttpContext.Request.Path} was not found.");

                context.Result = new ObjectResult(notFound)
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }

        private static string GetErrorMessage(int statusCode) => statusCode switch
        {
            StatusCodes.Status400BadRequest => "Bad request",
            StatusCodes.Status401Unauthorized => "Unauthorized",
            StatusCodes.Status403Forbidden => "Forbidden",
            StatusCodes.Status404NotFound => "Resource not found",
            StatusCodes.Status409Conflict => "Conflict",
            StatusCodes.Status500InternalServerError => "Internal server error",
            _ => "Error"
        };

        private static string GetErrorDetails(int statusCode, ActionExecutedContext context) => statusCode switch
        {
            StatusCodes.Status404NotFound => $"The requested resource at {context.HttpContext.Request.Path} was not found.",
            _ => $"An error occurred with status code {statusCode}."
        };
    }
}
