using MediatR;

namespace NetCoreBase.Application.Features.Items.Queries.GetAllItems
{
    public class GetAllItemsRequest : IRequest<IEnumerable<GetAllItemsResponse>>
    {
    }
}