using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Lists.Orders;
using Warehouse.Model.Dto.TmaRequest;
using Warehouse.Services.RequestService;

namespace Warehouse.Controllers;
[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IRequestService _requestService;

    public OrderController(ILogger<OrderController> logger, IRequestService requestService)
    {
        _logger = logger;
        _requestService = requestService;
    }

    [HttpGet("GetAllOrders"), Authorize(Roles = "Coordinator")]
    public async Task<ActionResult<IEnumerable<TmaRequest>>> GetAllOrders()
    {
        try
        {
            var result = await _requestService.GetAllRequestAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }

    [HttpPost("CreateOrder"), Authorize(Roles = "Coordinator")]
    public async Task<IActionResult> CreateOrder(CreateTmaRequestDto requestDto)
    {
        try
        {
            var result = await _requestService.AddRequestAsync(requestDto);
            return Ok("Request created");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }

    [HttpDelete("DeleteOrder"), Authorize(Roles = "Coordinator")]
    public async Task<ActionResult<bool>> DeleteOrder(int id)
    {
        try
        {
            var result = await _requestService.DeleteRequestAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }
    [HttpPatch("{id}/reject"), Authorize(Roles = "Coordinator")]
    public async Task<IActionResult> RejectRequest(int id)
    {
        try
        {
            var result = await _requestService.RejectRequestAsync(id);
                return Ok("Request rejected successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }
    [HttpPatch("{id}/approve"), Authorize(Roles = "Coordinator")]
    public async Task<IActionResult> ApproveRequest(int id)
    {
        try
        {
            var result = await _requestService.ApproveRequestAsync(id);
            return Ok("Request Approve successfully.");

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest();
        }
    }

}
