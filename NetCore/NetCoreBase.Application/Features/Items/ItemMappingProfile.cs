using AutoMapper;
using NetCoreBase.Application.Features.Items.Commands.AddItem;
using NetCoreBase.Application.Features.Items.Commands.UpdateItem;
using NetCoreBase.Application.Features.Items.Queries.GetAllItems;
using NetCoreBase.Application.Features.Items.Queries.GetItemById;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Features.Items
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            // Get All
            CreateMap<Item, GetAllItemsResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            // Get By Id
            CreateMap<Item, GetItemByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.LastModified))
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.LastModifiedBy));
            // Add
            CreateMap<AddItemRequest, Item>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Item, AddItemResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Create, opt => opt.MapFrom(src => src.Created));
            // Update
            // CreateMap<UpdateItemRequest, Item>()
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            
        }
    }
}
