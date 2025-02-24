using MediatR;
using NetCoreBase.Domain.Common;

namespace NetCoreBase.Application.Features.Items.Queries.GetAllItems
{
    public class GetAllItemsRequest : IRequest<OperationResponse<IEnumerable<GetAllItemsResponse>>>
    {
    }
}