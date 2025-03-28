using NetCoreBase.Application.Features.Items.Queries.GetItemById;

namespace NetCoreBase.Application.Features.Items.Queries.GetPagedItems
{
    public class GetPagedItemsResponse
    {
        public IEnumerable<GetItemByIdResponse>? Items { get; set; }
        public int TotalCount { get; set; }
    }
}