using AutoMapper;
using Warehouse.Lists.Units;
using Warehouse.Model.Dto.UnitDto;
using Warehouse.Repositories.UnitRepo;

namespace Warehouse.Services.Units;

public class UnitService : IUnitService
{
    private readonly ILogger<UnitService> _logger;
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public UnitService(ILogger<UnitService> logger, IUnitRepository unitRepository, IMapper mapper)
    {
        _logger = logger;
        _unitRepository = unitRepository;
        _mapper = mapper;
    }
    public async Task<bool> AddUnitAsync(CreateUnitDto unitDto)
    {
        try
        {
            var unitToAdd = _mapper.Map<Unit>(unitDto);
            return await _unitRepository.AddUnitAsync(unitToAdd);

        }catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<Unit>> GetAllUnitsAsync()
    {
        try
        {
            return await _unitRepository.GetAllUnitsAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new List<Unit>();
        }
    }

    public async Task<Unit> GetUnitByIdAsync(int id)
    {
        try
        {
            return await _unitRepository.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<bool> RemoveUnitAsync(int id)
    {
        try
        {
            return await _unitRepository.DeleteUnitAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }
}
