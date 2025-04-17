using System.Linq.Expressions;
using FluentValidation;
using Grpc.Core;
using MediatR;
using NetCoreBase.Domain.Common;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Interfaces;

namespace NetCoreBase.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, DeleteItemResponse>
    {
        private IMediator _mediator;
        private readonly IItemRepository _repository;
        private readonly IValidator<DeleteItemRequest> _validatorDeleteItem;

        public DeleteItemHandler(IMediator mediator, 
            IItemRepository repository,
            IValidator<DeleteItemRequest> validatorDeleteItem
            )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _repository = repository;
            _validatorDeleteItem = validatorDeleteItem ?? throw new ArgumentNullException(nameof(validatorDeleteItem));
        }

        public async Task<DeleteItemResponse> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            var isDeleted = await _repository.DeleteAsync(request.Id);
            return new DeleteItemResponse() { IsDeleted = isDeleted }; ;
        }
    }
}