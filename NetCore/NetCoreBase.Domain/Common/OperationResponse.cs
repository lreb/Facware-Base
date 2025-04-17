using NetCoreBase.Domain.Enum;

namespace NetCoreBase.Domain.Common
{
    public class OperationResponse<T>
    {
        private const string Success = "success";
        private const string Warning = "warning";
        private const string Fail = "fail";

        public string? OperationStatus { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Detail { get; set; }
        public T? Data { get; set; }

        public OperationResponse<T> SuccessOperation(T data, int statusCode, string message = "Operation completed successfully")
        {
            OperationStatus = Success;
            StatusCode = statusCode;
            Message = message;
            Data = data;
            return this;
        }

        public OperationResponse<T> WarningOperation(T? data, int statusCode, string message = "Operation completed with warning", string detail = "Details Operation")
        {
            OperationStatus = Warning;
            StatusCode = statusCode;
            Message = message;
            Detail = detail;
            Data = data;
            return this;
        }

        public OperationResponse<T> FailOperation(T data, int statusCode, string message = "Operation failed", string detail = "Details Operation")
        {
            OperationStatus = Fail;
            StatusCode = statusCode;
            Message = message;
            Detail = detail;
            Data = data;
            return this;
        }

        public OperationResponse<T> NotFoundOperation(string message = "Resource not found")
        {
            OperationStatus = Fail;
            StatusCode = 404;
            Message = message;
            return this;
        }

    }
}