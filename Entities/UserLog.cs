using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Entities.Types;

namespace backend.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Table("UserLogs")]
    public class UserLog
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EventDescription { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public UserEventType EventType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EventTime { get; set; } = DateTime.Now;
    }
}