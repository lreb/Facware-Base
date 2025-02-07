using NetCoreBase.Application.Features.Items.Queries.GetItemById;

namespace NetCoreBase.Application.Features.Items.Queries.GetPagedItems
{
    public class GetPagedItemsResponse
    {
        public IEnumerable<GetItemByIdResponse> Items { get; set; }
        public int TotalCount { get; set; }
    }

    // public class ItemDto
    // {
    //     public int Id { get; set; }
    //     public string Name { get; set; }
    //     public bool IsActive { get; set; }
    //     public DateTimeOffset Created { get; set; }
    //     public string CreatedBy { get; set; }
    //     public DateTimeOffset? LastModified { get; set; }
    //     public string LastModifiedBy { get; set; }
    // }
}