using DapperAssistant.Annotations;

namespace ELCODE.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    [SqlTable("Client")]
    public class Client
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название клиента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор ключевитости
        /// </summary>
        [SqlForeignKey("Importance")]
        public int ImportanceId { get; set; }

        /// <summary>
        /// Ключевитость
        /// </summary>
        [RelatedSqlEntity]
        public Importance Importance { get; set; }
    }
}