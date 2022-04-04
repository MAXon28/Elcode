using DapperAssistant;
using ELCODE.Models;
using ELCODE.Repositories.Interfaces;
using ELCODE.Services.Interfaces;

namespace ELCODE.Services.Implementations
{
    /// <inheritdoc cref="IRequestService"/>
    public class RequestService : IRequestService
    {
        /// <summary>
        /// Репозиторий запросов
        /// </summary>
        private readonly IRequestRepository _requestRepository;

        /// <summary>
        /// Репозиторий типоов запросов
        /// </summary>
        private readonly IRequestTypeRepository _requestTypeRepository;

        public RequestService(IRequestRepository requestRepository, IRequestTypeRepository requestTypeRepository)
        {
            _requestRepository = requestRepository;
            _requestTypeRepository = requestTypeRepository;
        }

        public async Task CreateRequest(int clientId, int requestTypeId, string description, int channelId, int priority, int mainRequestId = 0)
        {
            var request = new Request
            {
                RequestTypeId = requestTypeId,
                CreationDate = DateTime.Now,
                ClientId = clientId,
                Description = description,
                ChannelId = channelId,
                Priority = priority,
                MainRequestId = mainRequestId == default ? null : mainRequestId
            };

            await _requestRepository.AddAsync(request);
        }

        public async Task<IEnumerable<Request>> GetRequestsByIdAsync(int clientId)
        {
            var querySettings = new QuerySettings
            {
                ConditionField = "ClientId",
                ConditionType = ConditionType.EQUALLY,
                ConditionFieldValue = clientId
            };

            return await _requestRepository.GetWihoutJoinAsync(querySettings);
        }

        public async Task<IEnumerable<RequestType>> GetRequestTypesAsync()
        {
            return await _requestTypeRepository.GetAsync();
        }
    }
}