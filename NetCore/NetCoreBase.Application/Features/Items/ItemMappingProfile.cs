using AutoMapper;
using NetCoreBase.Application.Features.Items.Queries.GetItemById;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Features.Items
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Item, GetItemByIdResponse>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
