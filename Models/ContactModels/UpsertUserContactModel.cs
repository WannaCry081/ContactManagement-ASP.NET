using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace backend.Models.ContactModels
{
    /// <summary>
    /// Model for updating or inserting user contact information.
    /// </summary>
    public class UpsertUserContactModel
    {
        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        [Required(ErrorMessage = "First Name field is required.")]
        [RegularExpression(@"^[\w\d\s]+$", ErrorMessage = "Invalid first name.")]
        [StringLength(40, ErrorMessage = "First Name must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        [Required(ErrorMessage = "Last Name field is required.")]
        [RegularExpression(@"^[\w\d\s]+$", ErrorMessage = "Invalid last name.")]
        [StringLength(40, ErrorMessage = "Last Name must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email of the contact.
        /// </summary>
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email Address must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// </summary>
        [Required(ErrorMessage = "Phone No. field is required.")]
        [RegularExpression(@"^\+63\d+$", ErrorMessage = "Invalid phone no.")]
        [StringLength(13, ErrorMessage = "Phone number must be 13 characters long.", MinimumLength = 13)]
        public string PhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the delivery address of the contact.
        /// </summary>  
        [Required(ErrorMessage = "Delivery Address field is required.")]
        public string DeliveryAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the billing address of the contact
        /// </summary>
        [Required(ErrorMessage = "Billing Address field is required.")]
        public string BillingAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the item is marked as favorite.
        /// </summary>
        public bool IsFavorite { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the item is blocked.
        /// </summary>
        public bool IsBlock { get; set; } = false;
    }
}
