using FluentValidation;

namespace NetCoreBase.Application.Features.Items.Queries.GetPagedItems
{
    public class GetPagedItemsValidator : AbstractValidator<GetPagedItemsRequest>
    {
        public GetPagedItemsValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than 0.");
        }
    }
}