using DapperAssistant.Annotations;

namespace ELCODE.Models
{
    /// <summary>
    /// Тип запроса
    /// </summary>
    [SqlTable("RequestType")]
    public class RequestType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}