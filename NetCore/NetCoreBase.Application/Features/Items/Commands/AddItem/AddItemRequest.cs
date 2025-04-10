using MediatR;

namespace NetCoreBase.Application.Features.Items.Commands.AddItem
{
    public class AddItemRequest: IRequest<AddItemResponse>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
    }
}