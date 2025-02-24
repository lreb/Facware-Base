using MediatR;

namespace NetCoreBase.Application.Features.Items.Commands.AddItem
{
    public class AddItemRequest: IRequest<AddItemResponse>
    {
        public string Name { get; set; }
    }
}