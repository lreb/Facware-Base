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
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than 0.")
                .WithMessage("Price must have a maximum of 2 decimal places and a maximum of 18 digits in total.");
        }
    }
}