using AutoMapper;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Queries.GetByIdItemHandler
{
    public class GetByIdItemValidator
    {
    }

    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile()
        {
            CreateMap<Item, GetByIdItemQuery>()
                .ForMember(dest=>dest.ItemName, opt => opt.MapFrom(src=>src.Name));
            //CreateMap<Person, PersonRequestDto>();
            //CreateMap<Person, PersonListDto>();
        }
    }
}
