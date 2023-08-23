using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Entities.Types;

namespace backend.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Table("ContactLogs")]
    public class ContactLog
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public int UserLogId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserLog? UserLog { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EventDescription { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public ContactEventType? EventType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EventTime { get; set; } = DateTime.Now;
        
    }
}