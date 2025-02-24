using FluentValidation;

namespace NetCoreBase.Application.Features.Items.Commands.AddItem
{
    public class AddItemValidator : AbstractValidator<AddItemRequest>
    {
        public AddItemValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}