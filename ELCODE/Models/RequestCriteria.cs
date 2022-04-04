using DapperAssistant.Annotations;

namespace ELCODE.Models
{
    /// <summary>
    /// Критерии запроса
    /// </summary>
    [SqlTable("RequestCriteria")]
    public class RequestCriteria
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
        /// Тип запроса
        /// </summary>
        [RelatedSqlEntity]
        public RequestType RequestType { get; set; }
    }
}