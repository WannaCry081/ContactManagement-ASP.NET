namespace backend.Models.ContactModels
{
    /// <summary>
    /// Model for retrieving user contact information.
    /// </summary>
    public class GetUserContactModel
    {
        /// <summary>
        /// Gets or sets the ID of the contact.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email of the contact.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// </summary>
        public string PhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the delivery address of the contact.
        /// </summary>
        public string DeliveryAddress { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the billing address of the contact
        /// </summary>
        public string BillingAddress { get; set; } = string.Empty;
    }
}
