using AutoMapper;
using Grpc.Core;
using MediatR;
using NetCoreBase.Domain.Common;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Enum;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Features.Items.Queries.GetItemById
{
    /// <summary>
    /// Get item by id request object
    /// </summary>
    public record GetItemByIdRequest : IRequest<GetItemByIdResponse>
    {
        /// <summary>
        /// Item id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Get item by id handler busines logic, consumes item repository service
        /// </summary>
        public class GetByIdItemHandler : IRequestHandler<GetItemByIdRequest, GetItemByIdResponse>
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
            public async Task<GetItemByIdResponse> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
            {
                var item = await _repository.GetByIdAsyncNoTracking(request.Id, cancellationToken);
                //_ = item ?? throw new KeyNotFoundException($"{nameof(Item)} with id {request.Id} not found.");
                
                return _mapper.Map<GetItemByIdResponse>(item);

                //if(item is null) 
                //    return new OperationResponse<GetItemByIdResponse>().WarningOperation(data, (int)CoreHttpStatusCode.NotFound, $"{typeof(Item)} Not found");
                //else
                //    return new OperationResponse<GetItemByIdResponse>().SuccessOperation(data, (int)CoreHttpStatusCode.NotFound, $"{typeof(Item)} successfully");
            }
        }
    }
}
