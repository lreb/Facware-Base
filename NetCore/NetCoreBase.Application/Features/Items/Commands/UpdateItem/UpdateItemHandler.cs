using AutoMapper;
using MediatR;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemRequest, Item>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public UpdateItemHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Item> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Item with Id {request.Id} not found.");
            }

            //var data = _mapper.Map<Item>(request);
            

            item.Name = request.Name;
            item.IsActive = request.IsActive;
            item.UpdatedAt = DateTimeOffset.UtcNow;
            item.UpdatedBy = "system"; // TODO: Get current user

            var updatedData = await _repository.UpdateAsync(item);

            return updatedData;
        }
    }
}