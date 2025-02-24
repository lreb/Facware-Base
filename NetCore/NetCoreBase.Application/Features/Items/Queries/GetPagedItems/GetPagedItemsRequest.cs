using MediatR;

namespace NetCoreBase.Application.Features.Items.Queries.GetPagedItems
{
    public class GetPagedItemsRequest : IRequest<GetPagedItemsResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}