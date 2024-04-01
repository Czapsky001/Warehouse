using Microsoft.EntityFrameworkCore;
using Warehouse.DatabaseConnector;
using Warehouse.Lists.Items;

namespace Warehouse.Repositories.ItemsRepo
{
    public class ItemRepository : IItemRepository
    {
        private readonly ILogger<ItemRepository> _logger;
        private readonly DatabaseContext _context;

        public ItemRepository(ILogger<ItemRepository> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;

        }
        public async Task<bool> AddItemAsync(Item item)
        {
            try
            {
                await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();
                return true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            try
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            try
            {
                return await _context.Items.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Item>();
            }
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            try
            {
                var findedItem = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
                return findedItem;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            try
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
