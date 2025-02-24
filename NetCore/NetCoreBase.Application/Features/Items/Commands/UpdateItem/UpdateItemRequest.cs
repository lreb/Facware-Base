using MediatR;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemRequest : IRequest<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}