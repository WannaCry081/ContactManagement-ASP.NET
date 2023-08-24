using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    /// <summary>
    /// Entity class representing user contacts.
    /// </summary>
    [Table("Contacts")]
    public class Contact
    {
        /// <summary>
        /// Gets or sets the ID of the contact.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user associated with the contact.
        /// </summary>
        [ForeignKey("Users")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the contact.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        [StringLength(40)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        [StringLength(40)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email of the contact.
        /// </summary>
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// </summary>
        [StringLength(14)]
        public string PhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the delivery address of the contact.
        /// </summary>
        public string DeliveryAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the billing address of the contact
        /// </summary>
        public string BillingAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the timestamp of when the contact was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets a value indicating whether the item is marked as favorite.
        /// </summary>
        public bool IsFavorite { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the item is blocked.
        /// </summary>
        public bool IsBlock { get; set; } = false;

        /// <summary>
        /// Gets or sets the timestamp of when the contact was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
