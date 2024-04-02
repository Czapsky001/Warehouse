using Warehouse.Lists.Items;
using Warehouse.Model.Dto.Items;

namespace Warehouse.Services.Items;

public interface IItemService
{
    Task<bool> AddItemAsync(CreateItemDto item);
    Task<bool> RemoveItemAsync(int id);
    Task<bool> UpdateItemAsync(UpdateItemDto item);
    Task<IEnumerable<Item>> GetAllItemsAsync();

    Task<Item> GetItemByIdAsync(int id);

}
