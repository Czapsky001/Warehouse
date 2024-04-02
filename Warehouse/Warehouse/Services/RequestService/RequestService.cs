using AutoMapper;
using Warehouse.Lists.Orders;
using Warehouse.Model.Dto.TmaRequest;
using Warehouse.Repositories.OrdersRepo;

namespace Warehouse.Services.RequestService
{
    public class RequestService : IRequestService
    {
        private readonly ILogger<RequestService> _logger;
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public RequestService(ILogger<RequestService> logger, IRequestRepository requestRepository, IMapper mapper)
        {
            _logger = logger;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddRequestAsync(CreateTmaRequestDto request)
        {
            try
            {
                var requestToAdd = _mapper.Map<TmaRequest>(request);

                await _requestRepository.AddRequestAsync(requestToAdd);
                return true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> ApproveRequestAsync(int id)
        {
            try
            {
                var findedRequest = await _requestRepository.GetRequestByIdAsync(id);
                findedRequest.OrderStatus = OrderStatus.Approve;
                await _requestRepository.UpdateRequestAsync(findedRequest);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteRequestAsync(int id)
        {
            try
            {
                return await _requestRepository.RemoveRequestAsync(id);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<TmaRequest>> GetAllRequestAsync()
        {
            try
            {
                return await _requestRepository.GetAllRequestAsync();
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<TmaRequest>();
            }
        }

        public async Task<TmaRequest> GetRequestById(int id)
        {
            try
            {
                return await _requestRepository.GetRequestByIdAsync(id);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> RejectRequestAsync(int id)
        {
            try
            {
                var findedRequest = await _requestRepository.GetRequestByIdAsync(id);
                findedRequest.OrderStatus = OrderStatus.Reject;
                await _requestRepository.UpdateRequestAsync(findedRequest);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
