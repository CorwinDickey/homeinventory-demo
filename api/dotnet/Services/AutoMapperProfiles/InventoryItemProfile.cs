using AutoMapper;
using Domain.Inventory;
using Services.Dtos;
using Services.Utils;

namespace Services.AutoMapperProfiles
{
    /// <summary>
    /// AutoMapper profile for the <see cref="InventoryItem"/> entity
    /// </summary>
    public class InventoryItemProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItemProfile"/> class.
        /// </summary>
        public InventoryItemProfile()
        {
            CreateMap<InventoryItem, InventoryItemDto>()
                .ForMember(
                    dest => dest.DatePurchased,
                    opt => opt.MapFrom(src => src.DatePurchased.ToIso()));

            CreateMap<InventoryItemDto, InventoryItem>()
                .ForMember(
                    dest => dest.DatePurchased,
                    opt => opt.MapFrom(src => DateTimeOffset.Parse(src.DatePurchased)));

            CreateMap<InventoryItem, InventoryItem>()
                .ForMember(
                    dest => dest.ParentEntityId,
                    opt => opt.MapFrom(src => src.Id));
        }
    }
}
