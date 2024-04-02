using Warehouse.Lists.Units;

namespace Warehouse.Repositories.UnitRepo
{
    public interface IUnitRepository
    {
        Task<bool> AddUnitAsync(Unit unit);
        Task<bool> DeleteUnitAsync(int id);
        Task<IEnumerable<Unit>> GetAllUnitsAsync();
        Task<Unit> GetByIdAsync(int id);
    }
}
