using Microsoft.EntityFrameworkCore;
using Warehouse.DatabaseConnector;
using Warehouse.Lists.Orders;

namespace Warehouse.Repositories.OrdersRepo
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ILogger<RequestRepository> _logger;
        private readonly DatabaseContext _context;
        public RequestRepository(ILogger<RequestRepository> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<bool> AddRequestAsync(TmaRequest request)
        {
            try
            {
                var unit = await _context.Units.FirstOrDefaultAsync(u => u.UnitId == request.UnitId);
                var item = await _context.Items.FirstOrDefaultAsync(i => i.ItemId == request.ItemId);
                if(request.Quantity > item.Quantity)
                {
                    _logger.LogInformation($"Quantity of item is lower than quantity request. Quantity of item is {item.Quantity}");
                    return false;
                }
                if(unit == null || item == null) 
                {
                    _logger.LogInformation("Unit or item doesn't exist with those IDs.");
                    return false;
                }
                request.Item = item;
                request.Unit = unit;
                request.OrderStatus = OrderStatus.New;
                await _context.Requests.AddAsync(request);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public async Task<bool> RemoveRequestAsync(int id)
        {
            try
            {
                var requestToDelete = await _context.Requests.FirstOrDefaultAsync(x => x.Id == id);
                if(requestToDelete == null ) 
                {
                    _logger.LogInformation("Request doesn't exist");
                    return false;
                }
                _context.Requests.Remove(requestToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<TmaRequest>> GetAllRequestAsync()
        {
            try
            {
                return await _context.Requests
                    .Include(e => e.Unit)
                    .Include(e => e.Item)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<TmaRequest>();
            }
        }

        public async Task<bool> UpdateRequestAsync(TmaRequest request)
        {
            try
            {
                _context.Requests.Update(request);
                await _context.SaveChangesAsync();
                return true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<TmaRequest> GetRequestByIdAsync(int id)
        {
            try
            {
                var result = await _context.Requests.FirstOrDefaultAsync(r => r.Id == id);
                if (result == null)
                {
                    _logger.LogInformation($"Request with id: {id} doesn't exist");
                }
                return result;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
