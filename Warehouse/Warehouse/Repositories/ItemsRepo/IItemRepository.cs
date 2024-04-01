using Warehouse.Lists.Items;

namespace Warehouse.Repositories.ItemsRepo
{
    public interface IItemRepository
    {
        Task<bool> AddItemAsync(Item item);
        Task<bool> DeleteItemAsync(Item item);
        Task<bool> UpdateItemAsync(Item item);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);

    }
}
