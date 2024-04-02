using Warehouse.Lists.Units;
using Warehouse.Model.Dto.UnitDto;

namespace Warehouse.Services.Units
{
    public interface IUnitService
    {
        Task<bool> AddUnitAsync(CreateUnitDto unit);
        Task<bool> RemoveUnitAsync(int id);
        Task<IEnumerable<Unit>> GetAllUnitsAsync();
        Task<Unit> GetUnitByIdAsync(int id);
    }
}
