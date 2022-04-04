using ELCODE.Models;

namespace ELCODE.Services.Interfaces
{
    /// <summary>
    /// Севрис запросов
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Получить запросы конкретного клиента
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента </param>
        /// <returns> Запросы конкретного клиента </returns>
        public Task<IEnumerable<Request>> GetRequestsByIdAsync(int clientId);

        /// <summary>
        /// Получить типы запросов
        /// </summary>
        /// <returns> Типы запросов </returns>
        public Task<IEnumerable<RequestType>> GetRequestTypesAsync();

        /// <summary>
        /// Создать запрос
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента </param>
        /// <param name="requestTypeId"> Идентификатор типа запроса </param>
        /// <param name="description"> Содержимое запроса </param>
        /// <param name="channelId"> Идентификатор канала </param>
        /// <param name="priority"> Приоритет </param>
        /// <param name="mainRequestId"> Идентификатор запроса, по которому происходит уточнение </param>
        /// <returns> </returns>
        public Task CreateRequest(int clientId, int requestTypeId, string description, int channelId, int priority, int mainRequestId = default);
    }
}