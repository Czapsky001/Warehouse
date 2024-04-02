using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Lists.Units;
using Warehouse.Model.Dto.UnitDto;
using Warehouse.Services.Units;

namespace Warehouse.Controllers;
[ApiController]
[Route("[controller]")]


public class UnitController : ControllerBase
{
    private readonly ILogger<UnitController> _logger;
    private readonly IUnitService _unitService;

    public UnitController(ILogger<UnitController> logger, IUnitService service)
    {
        _logger = logger;
        _unitService = service;
    }
    [HttpGet("GetAllUnits"), Authorize(Roles = "Coordinator, Employee")]
    public async Task<ActionResult<IEnumerable<Unit>>> GetAllUnits()
    {
        try
        {
            var result = await _unitService.GetAllUnitsAsync();
            return Ok(result);
        }catch(Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }
    [HttpPost("CreateUnit"), Authorize(Roles = "Coordinator, Employee")]
    public async Task<ActionResult<Unit>> CreateUnit([FromBody] CreateUnitDto unit)
    {
        try
        {
            var result = await _unitService.AddUnitAsync(unit);
            return Ok(result);
        }catch(Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }
    [HttpDelete("DeleteUnit"), Authorize(Roles = "Coordinator, Employee")]
    public async Task<ActionResult<bool>> DeleteUnit(int id)
    {
        try
        {
            var result = await _unitService.RemoveUnitAsync(id);
            return Ok(result);
        }catch(Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }
}
