using AutoMapper;
using NetCoreBase.Domain.Entities;
using FluentValidation;

namespace NetCoreBase.Application.Queries.GetItemById
{
    public class GetByIdItemValidator : AbstractValidator<GetItemByIdRequest>
    {
        public GetByIdItemValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }

    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile()
        {
            CreateMap<Item, GetItemByIdResponse>()
                .ForMember(dest=>dest.ItemName, opt => opt.MapFrom(src=>src.Name));
        }
    }
}
