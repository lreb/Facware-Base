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
        public required string ItemName { get; set; }
    }
}
