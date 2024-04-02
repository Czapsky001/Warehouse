using Warehouse.Lists.Orders;
using Warehouse.Model.Dto.TmaRequest;

namespace Warehouse.Services.RequestService
{
    public interface IRequestService
    {
        Task<bool> AddRequestAsync(CreateTmaRequestDto request);
        Task<bool> DeleteRequestAsync(int id);

        Task<bool> RejectRequestAsync(int id);
        Task<bool> ApproveRequestAsync(int id);
        Task<IEnumerable<TmaRequest>> GetAllRequestAsync();
        Task<TmaRequest> GetRequestById(int id);
    }
}
