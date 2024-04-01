using Warehouse.Lists.Items;
using Warehouse.Repositories.ItemsRepo;

namespace Warehouse.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly ILogger<ItemService> _logger;
        private readonly IItemRepository _itemRepository;

        public ItemService(ILogger<ItemService> logger, IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            _logger = logger;
        }
        public async Task<bool> AddItemAsync(Item item)
        {
            try
            {
                return await _itemRepository.AddItemAsync(item);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            try
            {
                return await _itemRepository.GetAllItemsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            try
            {
                return await _itemRepository.GetItemByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RemoveItemAsync(Item item)
        {
            try
            {
                return await _itemRepository.DeleteItemAsync(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public Task<bool> UpdateItemAsync(Item item)
        {
            try
            {
                return _itemRepository.UpdateItemAsync(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
