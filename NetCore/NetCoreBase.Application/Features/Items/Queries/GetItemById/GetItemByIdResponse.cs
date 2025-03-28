namespace NetCoreBase.Application.Features.Items.Queries.GetItemById
{
    /// <summary>
    /// Item query response object
    /// </summary>
    public class GetItemByIdResponse
    {
        /// <summary>
        /// Item name
        /// </summary>
        /// <value>string</value>
        public required string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
