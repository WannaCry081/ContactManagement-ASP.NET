using System.ComponentModel.DataAnnotations;

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
        [MaxLength(40, ErrorMessage = "Maximum length for the First Name field is 40 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the First Name field is 1 character.")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        [Required(ErrorMessage = "Last Name field is required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Last Name field is 40 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Last Name field is 1 character.")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email of the contact.
        /// </summary>
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Email field is 100 characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for the Email field is 3 characters.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// </summary>
        [Required(ErrorMessage = "Phone No. field is required.")]
        [MaxLength(14, ErrorMessage = "Maximum length for the Phone No. field is 14 characters.")]
        [MinLength(11, ErrorMessage = "Minimum length for the Phone No. field is 11 characters.")]
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
    }
}
