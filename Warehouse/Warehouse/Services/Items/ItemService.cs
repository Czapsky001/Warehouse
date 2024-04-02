using AutoMapper;
using Warehouse.Lists.Items;
using Warehouse.Model.Dto.Items;
using Warehouse.Repositories.ItemsRepo;

namespace Warehouse.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly ILogger<ItemService> _logger;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(ILogger<ItemService> logger, IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> AddItemAsync(CreateItemDto itemDto)
        {
            try
            {
                var itemToAdd = _mapper.Map<Item>(itemDto);
                return await _itemRepository.AddItemAsync(itemToAdd);
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

        public async Task<bool> RemoveItemAsync(int id)
        {
            try
            {
                var existItem = await _itemRepository.GetItemByIdAsync(id);
                return await _itemRepository.DeleteItemAsync(existItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateItemAsync(UpdateItemDto itemDto)
        {
            try
            {
                var itemToUpdate = _mapper.Map<Item>(itemDto);
                return await _itemRepository.UpdateItemAsync(itemToUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
