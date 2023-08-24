using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    /// <summary>
    /// Represents a user log entry.
    /// </summary>
    [Table("UserLogs")]
    public class UserLog
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user log.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user associated with the log entry.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the log entry.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the description of the event associated with the log entry.
        /// </summary>
        public string EventDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of the event associated with the log entry.
        /// </summary>
        public string EventType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the timestamp of the event associated with the log entry.
        /// </summary>
        public DateTime EventTime { get; set; } = DateTime.Now;
    }
}
