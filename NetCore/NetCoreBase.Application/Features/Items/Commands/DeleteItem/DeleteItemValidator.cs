using FluentValidation;

namespace NetCoreBase.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemValidator : AbstractValidator<DeleteItemRequest>
    {
        public DeleteItemValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}