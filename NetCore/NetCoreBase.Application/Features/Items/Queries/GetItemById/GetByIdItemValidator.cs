using FluentValidation;

namespace NetCoreBase.Application.Features.Items.Queries.GetItemById
{
    /// <summary>
    /// Validator for GetItemByIdRequest <see cref="GetItemByIdRequest"/>"/>
    /// </summary>
    public class GetByIdItemValidator : AbstractValidator<GetItemByIdRequest>
    {
        public GetByIdItemValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
