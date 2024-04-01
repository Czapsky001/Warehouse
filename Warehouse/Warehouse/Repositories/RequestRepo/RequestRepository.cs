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
        public async Task<bool> AddOrderAsync(TmaRequest request)
        {
            try
            {
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
        public async Task<bool> RemoveOrderAsync(TmaRequest request)
        {
            try
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<TmaRequest>> GetAllOrdersAsync()
        {
            try
            {
                return await _context.Requests.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<TmaRequest>();
            }
        }


    }
}
