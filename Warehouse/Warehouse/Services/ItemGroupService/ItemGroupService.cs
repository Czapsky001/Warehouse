using AutoMapper;
using Warehouse.Lists.Items;
using Warehouse.Model.Dto.ItemGroup;
using Warehouse.Repositories.ItemGroupRepo;

namespace Warehouse.Services.ItemGroupService;

public class ItemGroupService : IItemGroupService
{
    private readonly ILogger<ItemGroupService> _logger;
    private readonly IItemGroupRepository _itemGroupRepository;
    private readonly IMapper _mapper;

    public ItemGroupService(ILogger<ItemGroupService> logger, IItemGroupRepository itemGroupRepository, IMapper mapper)
    {
        _itemGroupRepository = itemGroupRepository;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<bool> AddItemGroupAsync(CreateItemGroupDto itemGroupDto)
    {
        try
        {
            var itemToAdd = _mapper.Map<ItemGroup>(itemGroupDto);
            await _itemGroupRepository.AddItemGroupAsync(itemToAdd);
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
            return await _itemGroupRepository.DeleteItemGroupAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }

    public async Task<IEnumerable<ItemGroup>> GetAllItemsGroupAsync()
    {
        try
        {
            return await _itemGroupRepository.GetAllItemGroupAsync();
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
            return await _itemGroupRepository.GetItemGroupById(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}
