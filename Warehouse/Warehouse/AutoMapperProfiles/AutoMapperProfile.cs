using AutoMapper;
using Warehouse.Lists.Items;
using Warehouse.Lists.Orders;
using Warehouse.Lists.Units;
using Warehouse.Model.Dto.ItemGroup;
using Warehouse.Model.Dto.Items;
using Warehouse.Model.Dto.TmaRequest;
using Warehouse.Model.Dto.UnitDto;

namespace Warehouse.AutoMapperProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUnitDto, Unit>();
        CreateMap<Unit, CreateUnitDto>();
        CreateMap<Item, CreateItemDto>();
        CreateMap<CreateItemDto, Item>();
        CreateMap<ItemGroup, CreateItemGroupDto>();
        CreateMap<CreateItemGroupDto, ItemGroup>();
        CreateMap<CreateTmaRequestDto, TmaRequest>();
        CreateMap<TmaRequest, CreateTmaRequestDto>();
        CreateMap<Item, UpdateItemDto>();
        CreateMap<UpdateItemDto, Item>();
    }
}
