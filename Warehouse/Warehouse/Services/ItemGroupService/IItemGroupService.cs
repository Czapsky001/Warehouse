using Warehouse.Lists.Items;
using Warehouse.Model.Dto.ItemGroup;

namespace Warehouse.Services.ItemGroupService
{
    public interface IItemGroupService
    {
        Task<bool> AddItemGroupAsync(CreateItemGroupDto itemGroupDto);
        Task<bool> DeleteItemGroupAsync(int id);
        Task<IEnumerable<ItemGroup>> GetAllItemsGroupAsync();
        Task<ItemGroup> GetItemGroupById(int id);
    }
}
