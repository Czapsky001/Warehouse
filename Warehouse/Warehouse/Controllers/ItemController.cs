﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Lists.Items;
using Warehouse.Services.Items;

namespace Warehouse.Controllers;
[ApiController]
[Route("[controller]")]

public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    private readonly IItemService _itemService;

    public ItemController(ILogger<ItemController> logger, IItemService itemService)
    {
        _logger = logger;
        _itemService = itemService;
    }

    [HttpGet("items"), Authorize(Roles = "Coordinator")]
    public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
    {
        try
        {
            var result = await _itemService.GetAllItemsAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest(ex.Message);
        }
    }


}