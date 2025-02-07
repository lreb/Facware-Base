using FluentValidation;

namespace NetCoreBase.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemValidator : AbstractValidator<UpdateItemRequest>
    {
        public UpdateItemValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive is required.");
        }
    }
}