using AutoMapper;
using MediatR;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Features.Items.Queries.GetAllItems
{
    // Handler class
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsRequest, IEnumerable<GetAllItemsResponse>>
    {
        /// <summary>
            /// AutoMapper instance
            /// </summary>
            public readonly IMapper _mapper;
            /// <summary>
            /// Item repository service
            /// </summary>
            public IItemRepository _repository { get; set; }

        public GetAllItemsHandler(IItemRepository itemRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _repository = itemRepository;
        }

        public async Task<IEnumerable<GetAllItemsResponse>> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllAsync();

            var data = _mapper.Map<IEnumerable<GetAllItemsResponse>>(items);

            return data;
        }
    }
}