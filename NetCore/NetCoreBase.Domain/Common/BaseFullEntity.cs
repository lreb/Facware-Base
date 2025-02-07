namespace NetCoreBase.Domain.Common
{
    /// <summary>
    /// Implements the base full entity properties id, logical delete and audit properties
    /// </summary>
    public abstract class BaseFullEntity : BaseAuditableEntity
    {
        /// <summary>
        /// Logical delete flag
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
