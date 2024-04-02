using Warehouse.Lists.Orders;

namespace Warehouse.Repositories.OrdersRepo
{
    public interface IRequestRepository
    {
        Task<bool> AddRequestAsync(TmaRequest request);
        Task<bool> RemoveRequestAsync(int id);
        Task<bool> UpdateRequestAsync(TmaRequest request);
        Task<IEnumerable<TmaRequest>> GetAllRequestAsync();
        Task<TmaRequest> GetRequestByIdAsync(int id);
    }
}
