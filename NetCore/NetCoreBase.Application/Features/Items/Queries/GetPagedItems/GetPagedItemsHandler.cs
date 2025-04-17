using AutoMapper;
using MediatR;
using NetCoreBase.Application.Features.Items.Queries.GetItemById;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Features.Items.Queries.GetPagedItems
{
    public class GetPagedItemsHandler : IRequestHandler<GetPagedItemsRequest, GetPagedItemsResponse>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public GetPagedItemsHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetPagedItemsResponse> Handle(GetPagedItemsRequest request, CancellationToken cancellationToken)
        {
            var (items, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize, cancellationToken);

            var itemDtos = _mapper.Map<IEnumerable<GetItemByIdResponse>>(items);

            return new GetPagedItemsResponse
            {
                Items = itemDtos,
                TotalCount = totalCount
            };
        }
    }
}