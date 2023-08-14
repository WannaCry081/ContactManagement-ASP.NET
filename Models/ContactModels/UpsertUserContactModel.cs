using System.ComponentModel.DataAnnotations;

namespace backend.Models.ContactModels
{
    /// <summary>
    /// 
    /// </summary>
    public class UpsertUserContactModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "First Name field is Required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the First Name field is 40 Characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the First Name field is 1 Character.")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Last Name field is Required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Last Name field is 40 Characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Last Name field is 1 Character.")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Email field is Required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Email field is 100 Characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for the Email field is 3 Characters.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Phone No. field is Required.")]
        [MaxLength(14, ErrorMessage = "Maximum length for the Phone No. field is 14 Characters.")]
        [MinLength(11, ErrorMessage = "Minimum length for the Phone No. field is 11 Characters.")]
        public string PhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Address field is Required.")]
        public string Address { get; set; } = string.Empty;
    }
}