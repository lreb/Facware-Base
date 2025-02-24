using MediatR;

namespace NetCoreBase.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemRequest : IRequest<DeleteItemResponse>
    {
        public int Id { get; set; }
    }
}