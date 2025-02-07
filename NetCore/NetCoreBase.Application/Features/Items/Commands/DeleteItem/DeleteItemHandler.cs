using MediatR;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, DeleteItemResponse>
    {
        private readonly IItemRepository _repository;

        public DeleteItemHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteItemResponse> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            var isDeleted = await _repository.DeleteAsync(request.Id);
            return new DeleteItemResponse { IsDeleted = isDeleted };
        }
    }
}