using AutoMapper;
using MediatR;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Queries.GetByIdItemHandler
{
    public class ItemGetByIdQuery : IRequest<GetByIdItemQuery>
    {
        public int Id { get; set; }

        public class GetByIdItemHandler : IRequestHandler<ItemGetByIdQuery, GetByIdItemQuery>
        {
            public readonly IMapper _mapper;

            public IItemRepository _repository { get; set; }

            public GetByIdItemHandler(IMapper mapper, IItemRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<GetByIdItemQuery> Handle(ItemGetByIdQuery request, CancellationToken cancellationToken)
            {
                var item = _repository.GetById(request.Id);

                var data = _mapper.Map<GetByIdItemQuery>(item);

                return data;
            }
        }
    }
   
}
