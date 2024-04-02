using Microsoft.EntityFrameworkCore;
using Warehouse.DatabaseConnector;
using Warehouse.Lists.Items;
using Warehouse.Model.Dto.ItemGroup;

namespace Warehouse.Repositories.ItemGroupRepo
{
    public class ItemGroupRepository : IItemGroupRepository
    {
        private readonly ILogger<ItemGroupRepository> _logger;
        private readonly DatabaseContext _context;

        public ItemGroupRepository(ILogger<ItemGroupRepository> logger, DatabaseContext context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> AddItemGroupAsync(ItemGroup itemGroupDto)
        {
            try
            {
                await _context.ItemsGroup.AddAsync(itemGroupDto);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteItemGroupAsync(int id)
        {
            try
            {
                var itemGroupToDelete = await _context.ItemsGroup.FirstOrDefaultAsync(i => i.ItemGroupId == id);
                if(itemGroupToDelete == null)
                {
                    _logger.LogInformation("Item with that id doesn't exist");
                    return false;
                }
                _context.ItemsGroup.Remove(itemGroupToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<ItemGroup>> GetAllItemGroupAsync()
        {
            try
            {
                return await _context.ItemsGroup.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<ItemGroup>();
            }
        }

        public async Task<ItemGroup> GetItemGroupById(int id)
        {
            try
            {
                var findedItemGroup = await _context.ItemsGroup.FirstOrDefaultAsync(i => i.ItemGroupId == id);
                return findedItemGroup;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
