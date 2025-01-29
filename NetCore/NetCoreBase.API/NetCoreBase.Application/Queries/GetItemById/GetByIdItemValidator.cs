using AutoMapper;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Queries.GetItemById
{
    public class GetByIdItemValidator
    {
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
