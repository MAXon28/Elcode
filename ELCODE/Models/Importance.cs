using DapperAssistant.Annotations;

namespace ELCODE.Models
{
    /// <summary>
    /// Ключевитость
    /// </summary>
    [SqlTable("Importance")]
    public class Importance
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип ключевитости
        /// </summary>
        public string Type { get; set; }
    }
}