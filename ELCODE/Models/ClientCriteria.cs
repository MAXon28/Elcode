using DapperAssistant.Annotations;

namespace ELCODE.Models
{
    /// <summary>
    /// Клиентские критерии
    /// </summary>
    [SqlTable("ClientCriteria")]
    public class ClientCriteria
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Идентификатор типа запроса
        /// </summary>
        [SqlForeignKey("RequestType")]
        public int RequestTypeId { get; set; }

        /// <summary>
        /// Идентификатор ключевитости
        /// </summary>
        [SqlForeignKey("Importance")]
        public int ImportanceId { get; set; }

        /// <summary>
        /// Тип запроса
        /// </summary>
        [RelatedSqlEntity]
        public RequestType RequestType { get; set; }

        /// <summary>
        /// Ключевитость
        /// </summary>
        [RelatedSqlEntity]
        public Importance Importance { get; set; }
    }
}