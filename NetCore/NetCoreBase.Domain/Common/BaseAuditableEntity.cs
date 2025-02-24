namespace NetCoreBase.Domain.Common
{
    /// <summary>
    /// Implements the base auditable entity to identify the created and last modified date and user
    /// </summary>
    public abstract class BaseAuditableEntity : BaseEntity
    {
        /// <summary>
        /// Date and time when the entity was created
        /// </summary>
        public DateTimeOffset Created { get; set; }
        /// <summary>
        /// Created by user name or id 
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Date and time when the entity was last modified
        /// </summary>
        public DateTimeOffset LastModified { get; set; }
        /// <summary>
        /// Last modified by user name or id
        /// </summary>
        public string? LastModifiedBy { get; set; }
    }
}
