using System.ComponentModel;

namespace NetCoreBase.Domain.Enum
{
    public enum OperationStatus
    {
        [Description("success")]
        Success,
        [Description("warning")]
        Warning,
        [Description("fail")]
        Fail
    }
}