using MediatR;
using NetCoreBase.Domain.Common;

namespace NetCoreBase.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemRequest : IRequest<DeleteItemResponse>
    {
        public long Id { get; set; }
    }
}