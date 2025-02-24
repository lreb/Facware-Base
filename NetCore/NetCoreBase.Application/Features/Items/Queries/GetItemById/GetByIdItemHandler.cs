using AutoMapper;
using MediatR;
using NetCoreBase.Domain.Common;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Features.Items.Queries.GetItemById
{
    /// <summary>
    /// Get item by id request object
    /// </summary>
    public class GetItemByIdRequest : IRequest<OperationResponse<GetItemByIdResponse>>
    {
        /// <summary>
        /// Item id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get item by id handler busines logic, consumes item repository service
        /// </summary>
        public class GetByIdItemHandler : IRequestHandler<GetItemByIdRequest, OperationResponse<GetItemByIdResponse>>
        {
            /// <summary>
            /// AutoMapper instance
            /// </summary>
            public readonly IMapper _mapper;
            /// <summary>
            /// Item repository service
            /// </summary>
            public IItemRepository _repository { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="mapper"></param>
            /// <param name="repository"></param>
            public GetByIdItemHandler(IMapper mapper, IItemRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            /// <summary>
            /// Handle get item by id request
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<OperationResponse<GetItemByIdResponse>> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
            {
                var item = await _repository.GetByIdAsync(request.Id);

                var data = _mapper.Map<GetItemByIdResponse>(item);

                var result = new OperationResponse<GetItemByIdResponse>().SuccessOperation(data, "Item retrieved successfully");

                return result;
            }
        }
    }
}
