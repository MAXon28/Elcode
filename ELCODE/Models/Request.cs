using DapperAssistant.Annotations;

namespace ELCODE.Models
{
    /// <summary>
    /// Запрос
    /// </summary>
    [SqlTable("Request")]
    public class Request
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор типа запроса
        /// </summary>
        [SqlForeignKey("RequestType")]
        public int RequestTypeId { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        [SqlForeignKey("Client")]
        public int ClientId { get; set; }

        /// <summary>
        /// Содержание запроса
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ответ на запрос
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Идентификатор канала
        /// </summary>
        [SqlForeignKey("Channel")]
        public int ChannelId { get; set; }

        /// <summary>
        /// Приоритет
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Идентификатор главного запроса (если текущий является уточняющим)
        /// </summary>
        [SqlForeignKey("Request")]
        public int? MainRequestId { get; set; }

        /// <summary>
        /// Тип запроса
        /// </summary>
        [RelatedSqlEntity]
        public RequestType RequestType { get; set; }

        /// <summary>
        /// Клиент
        /// </summary>
        [RelatedSqlEntity]
        public Client Client { get; set; }

        /// <summary>
        /// Канал связи
        /// </summary>
        [RelatedSqlEntity]
        public Channel Channel { get; set; }

        /// <summary>
        /// Главный запрос (если текущий является уточняющим)
        /// </summary>
        [RelatedSqlEntity]
        public Request? MainRequest { get; set; }
    }
}