using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using NetCoreBase.Domain.Common;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Features.Items.Queries.GetAllItems
{
    // Handler class
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsRequest, OperationResponse<IEnumerable<GetAllItemsResponse>>>
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

        public async Task<OperationResponse<IEnumerable<GetAllItemsResponse>>> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Define a predicate to filter items (e.g., items with a specific property value)
                // You can also use a more complex predicate if needed
                Expression<Func<Item, bool>> predicate = item => item.IsActive && item.Price > 0;
                
                var items = await _repository.GetAllAsync(predicate, cancellationToken);
                var data = _mapper.Map<IEnumerable<GetAllItemsResponse>>(items);
                var result = new OperationResponse<IEnumerable<GetAllItemsResponse>>().SuccessOperation(data, "Items retrieved successfully");
                return result;
            }
            catch (OperationCanceledException ex)
            {
                // Handle the cancellation
                // You can log the cancellation or take any other action you need
                throw new Exception("Operation was canceled.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}