using Warehouse.Lists.Orders;

namespace Warehouse.Repositories.OrdersRepo
{
    public interface IRequestRepository
    {
        Task<bool> AddOrderAsync(TmaRequest request);
        Task<bool> RemoveOrderAsync(TmaRequest request);
        Task<IEnumerable<TmaRequest>> GetAllOrdersAsync();
    }
}
