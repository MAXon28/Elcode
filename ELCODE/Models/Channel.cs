using DapperAssistant.Annotations;

namespace ELCODE.Models
{
    /// <summary>
    /// Канал связи
    /// </summary>
    [SqlTable("Channel")]
    public class Channel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название канала
        /// </summary>
        public string Name { get; set; }
    }
}