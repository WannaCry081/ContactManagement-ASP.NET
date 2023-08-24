using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Entities.Types;

namespace backend.Entities
{
    /// <summary>
    /// Represents a log entry for contact-related events.
    /// </summary>
    [Table("ContactLogs")]
    public class ContactLog
    {
        /// <summary>
        /// Gets or sets the unique identifier for the contact log entry.
        /// </summary>
        [Key]
        public int Id { get; set; } 

        /// <summary>
        /// Gets or sets the ID of the associated authenticated user.
        /// </summary> 
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the associated authenticated user.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated contact.
        /// </summary> 
        public int ContactId { get; set; }

        /// <summary>
        /// Gets or sets the associated contact.
        /// </summary>
        public Contact? Contact { get; set; }

        /// <summary>
        /// Gets or sets the description of the event associated with the contact log entry.
        /// </summary>
        public string EventDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of the event associated with the contact log entry.
        /// </summary>
        public ContactEventType? EventType { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the event associated with the contact log entry.
        /// </summary>
        public DateTime EventTime { get; set; } = DateTime.Now;
    }
}
