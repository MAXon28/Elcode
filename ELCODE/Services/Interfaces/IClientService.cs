using ELCODE.Models;

namespace ELCODE.Services.Interfaces
{
    /// <summary>
    /// Сервис клиентов
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Получить типы важности (ключевитость)
        /// </summary>
        /// <returns> Типы важности </returns>
        public Task<IEnumerable<Importance>> GetImportancesAsync();

        /// <summary>
        /// Получить клиентов
        /// </summary>
        /// <returns> Клиенты </returns>
        public Task<IEnumerable<Client>> GetClientsAsync();

        /// <summary>
        /// Получить идентифкатор ключевтости конкртеного клиента
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента </param>
        /// <returns> Идентифкатор ключевтости конкртеного клиента </returns>
        public Task<int> GetClientImportanceIdAsync(int clientId);

        /// <summary>
        /// Создать клиента
        /// </summary>
        /// <param name="name"> Название клиента </param>
        /// <param name="importanceId"> Идентификатор ключевитости </param>
        /// <returns></returns>
        public Task CreateClientAsync(string name, int importanceId);
    }
}