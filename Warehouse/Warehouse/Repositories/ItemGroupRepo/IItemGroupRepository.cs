using Warehouse.Lists.Items;
using Warehouse.Model.Dto.ItemGroup;

namespace Warehouse.Repositories.ItemGroupRepo
{
    public interface IItemGroupRepository
    {
        Task<bool> AddItemGroupAsync(ItemGroup itemGroupDto);
        Task<bool> DeleteItemGroupAsync(int id);
        Task<IEnumerable<ItemGroup>> GetAllItemGroupAsync();
        Task<ItemGroup> GetItemGroupById(int id);
    }
}
