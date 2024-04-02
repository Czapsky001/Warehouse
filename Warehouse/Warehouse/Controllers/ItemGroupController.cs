using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Lists.Items;
using Warehouse.Model.Dto.ItemGroup;
using Warehouse.Model.Dto.Items;
using Warehouse.Services.ItemGroupService;

namespace Warehouse.Controllers;
[ApiController]
[Route("[controller]")]

public class ItemGroupController : ControllerBase
{
    private readonly ILogger<ItemGroupController> _logger;
    private readonly IItemGroupService _itemGroupService;

    public ItemGroupController(ILogger<ItemGroupController> logger, IItemGroupService itemGroupService)
    {
        _itemGroupService = itemGroupService;
        _logger = logger;
    }
    [HttpGet("GetAllItemGroup"), Authorize(Roles = "Coordinator")]
    public async Task<ActionResult<IEnumerable<ItemGroup>>> GetAllItemGroup()
    {
        try
        {
            var result = await _itemGroupService.GetAllItemsGroupAsync();
            return Ok(result);
        }catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }
    [HttpPost("CreateItemGroup"), Authorize(Roles = "Coordinator")]
    public async Task<ActionResult<bool>> CreateItemGroup([FromBody]CreateItemGroupDto itemGroupDto)
    {
        try
        {
            var result = await _itemGroupService.AddItemGroupAsync(itemGroupDto);
            return Ok(result);
        }catch(Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }
    [HttpDelete("DeleteItemGroup"), Authorize(Roles = "Coordinator")]
    public async Task<ActionResult<bool>> DeleteItemGroup(int id)
    {
        try
        {
            var result = await _itemGroupService.DeleteItemGroupAsync(id);
            return Ok(result);
        }catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }
}
