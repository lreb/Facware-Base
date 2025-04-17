using MediatR;

namespace NetCoreBase.Application.Features.Items.Queries.GetAllItems
{
    public record GetAllItemsRequest : IRequest<IEnumerable<GetAllItemsResponse>>
    {
    }
}