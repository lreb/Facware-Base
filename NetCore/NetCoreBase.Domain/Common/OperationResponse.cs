using NetCoreBase.Domain.Enum;

namespace NetCoreBase.Domain.Common
{
    public class OperationResponse<T>
    {
        private const string Success = "success";
        private const string Warning = "warning";
        private const string Fail = "fail";

        public string OperationStatus { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public OperationResponse<T> SuccessOperation(T data, string message = "Operation completed successfully")
        {
            OperationStatus = Success;
            StatusCode = 200;
            Message = message;
            Data = data;
            return this;
        }

        public OperationResponse<T> WarningOperation(T data, string message = "Operation completed with warning")
        {
            OperationStatus = Warning;
            StatusCode = 400;
            Message = message;
            Data = data;
            return this;
        }

        public OperationResponse<T> FailOperation(T data, string message = "Operation failed")
        {
            OperationStatus = Fail;
            StatusCode = 500;
            Message = message;
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