using AutoMapper;
using MediatR;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Queries.GetItemById
{
    public class GetItemByIdRequest : IRequest<GetItemByIdResponse>
    {
        public int Id { get; set; }

        public class GetByIdItemHandler : IRequestHandler<GetItemByIdRequest, GetItemByIdResponse>
        {
            public readonly IMapper _mapper;

            public IItemRepository _repository { get; set; }

            public GetByIdItemHandler(IMapper mapper, IItemRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<GetItemByIdResponse> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
            {
                var item = await _repository.GetByIdAsync(request.Id);

                var data = _mapper.Map<GetItemByIdResponse>(item);

                return data;
            }
        }
    }
}
