namespace ELCODE.Services.Interfaces
{
    /// <summary>
    /// Сервис расчёта приоритета
    /// </summary>
    public interface IPriorityService
    {
        /// <summary>
        /// Получить приоритет
        /// </summary>
        /// <param name="clientImportanceId"> Идентификатор ключевитости клиента </param>
        /// <param name="requestTypeId"> Идентификатор типа запроса </param>
        /// <param name="firstRequest"> Является ли запрос главным </param>
        /// <returns> Приоритет </returns>
        public Task<int> GerPriorityAsync(int clientImportanceId, int requestTypeId, bool firstRequest);
    }
}