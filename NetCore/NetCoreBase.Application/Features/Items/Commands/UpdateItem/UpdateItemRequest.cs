using MediatR;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemRequest : IRequest<Item>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}