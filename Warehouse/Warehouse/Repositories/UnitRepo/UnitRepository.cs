using Microsoft.EntityFrameworkCore;
using Warehouse.DatabaseConnector;
using Warehouse.Lists.Units;

namespace Warehouse.Repositories.UnitRepo
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ILogger<UnitRepository> _logger;
        private readonly DatabaseContext _context;

        public UnitRepository(ILogger<UnitRepository> logger, DatabaseContext databaseContext)
        {
            _context = databaseContext;
            _logger = logger;
        }

        public async Task<bool> AddUnitAsync(Unit unit)
        {
            try
            {
                await _context.Units.AddAsync(unit);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteUnitAsync(int id)
        {
            try
            {
                var itemToDelete = await _context.Units.FirstOrDefaultAsync(e => e.UnitId == id);
                if(itemToDelete == null)
                {
                    _logger.LogInformation("Item doesn't exist");
                    return false;
                }
                _context.Units.Remove(itemToDelete);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Unit>> GetAllUnitsAsync()
        {
            try
            {
                return await _context.Units.ToListAsync();

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<Unit>();
            }
        }

        public async Task<Unit> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Units.FirstOrDefaultAsync(u => u.UnitId == id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
