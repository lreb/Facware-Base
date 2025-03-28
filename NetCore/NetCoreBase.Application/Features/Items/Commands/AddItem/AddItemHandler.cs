using AutoMapper;
using MediatR;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Features.Items.Commands.AddItem
{

    public class AddItemHandler : IRequestHandler<AddItemRequest, AddItemResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public AddItemHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<AddItemResponse> Handle(AddItemRequest request, CancellationToken cancellationToken)
        {
            var newItem = _mapper.Map<Item>(request);
            newItem.IsActive = true;
            newItem.CreatedAt = DateTimeOffset.UtcNow;
            newItem.CreatedBy = "system"; // TODO: Get current user

            await _itemRepository.AddAsync(newItem);

            return _mapper.Map<AddItemResponse>(newItem);
        }
    }
}