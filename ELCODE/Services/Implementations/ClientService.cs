using DapperAssistant;
using ELCODE.Models;
using ELCODE.Repositories.Interfaces;
using ELCODE.Services.Interfaces;

namespace ELCODE.Services.Implementations
{
    /// <inheritdoc cref="IClientService"/>
    public class ClientService : IClientService
    {
        /// <summary>
        /// Репозиторий клиентов
        /// </summary>
        private readonly IClientRepository _clientRepository;

        /// <summary>
        /// Репозиторий важности (ключевитости)
        /// </summary>
        private readonly IImportanceRepository _importanceRepository;

        public ClientService(IClientRepository clientRepository, IImportanceRepository importanceRepository)
        {
            _clientRepository = clientRepository;
            _importanceRepository = importanceRepository;
        }

        public async Task CreateClientAsync(string name, int importanceId)
        {
            var client = new Client
            {
                Name = name,
                ImportanceId = importanceId
            };

            await _clientRepository.AddAsync(client);
        }

        public async Task<int> GetClientImportanceIdAsync(int clientId)
        {
            var querySettings = new QuerySettings
            {
                ConditionField = "Id",
                ConditionType = ConditionType.EQUALLY,
                ConditionFieldValue = clientId
            };

            var client = (await _clientRepository.GetWithConditionAsync(querySettings)).FirstOrDefault();

            return client.ImportanceId;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync() => await _clientRepository.GetAsync();

        public async Task<IEnumerable<Importance>> GetImportancesAsync() => await _importanceRepository.GetAsync();
    }
}