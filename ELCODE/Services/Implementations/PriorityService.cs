using DapperAssistant;
using ELCODE.Repositories.Interfaces;
using ELCODE.Services.Interfaces;

namespace ELCODE.Services.Implementations
{
    /// <inheritdoc cref="IPriorityService"/>
    public class PriorityService : IPriorityService
    {
        /// <summary>
        /// Репозиторий клиентских критериев
        /// </summary>
        private readonly IClientCriteriaRepository _clientCriteriaRepository;

        /// <summary>
        /// Репозиторий критериев запросов
        /// </summary>
        private readonly IRequestCriteriaRepository _requestCriteriaRepository;

        /// <summary>
        /// Словарь критериев запроса
        /// </summary>
        private readonly Dictionary<bool, string> _requestCriteriasDictionary = new Dictionary<bool, string>
        {
            [true] = "Первый запрос от клиента",
            [false] = "Наличие уточнений от клиента"
        };

        public PriorityService(IClientCriteriaRepository clientCriteriaRepository, IRequestCriteriaRepository requestCriteriaRepository)
        {
            _clientCriteriaRepository = clientCriteriaRepository;
            _requestCriteriaRepository = requestCriteriaRepository;
        }

        public async Task<int> GerPriorityAsync(int clientImportanceId, int requestTypeId, bool firstRequest)
        {
            var priority = 0;

            var querySettings = new QuerySettings
            {
                ConditionField = "RequestTypeId",
                ConditionType = ConditionType.EQUALLY,
                ConditionFieldValue = requestTypeId
            };

            var clientCriterias = await _clientCriteriaRepository.GetWithConditionAsync(querySettings);
            priority += clientCriterias
                .Where(criteria => criteria.ImportanceId == clientImportanceId)
                    .Select(criteria => criteria.Weight).Sum();

            var requestCriterias = await _requestCriteriaRepository.GetWithConditionAsync(querySettings);
            priority += requestCriterias
                .Where(criteria => criteria.Name == _requestCriteriasDictionary[firstRequest])
                    .Select(criteria => criteria.Weight).Sum();

            return priority;
        }
    }
}