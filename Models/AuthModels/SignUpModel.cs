using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.AuthModels
{
    /// <summary>
    /// Data model for user sign-up.
    /// </summary>
    public class SignUpModel
    {
        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        [Required(ErrorMessage = "First Name field is required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the First Name field is 40 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the First Name field is 1 character.")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        [Required(ErrorMessage = "Last Name field is required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Last Name field is 40 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Last Name field is 1 character.")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        [Required(ErrorMessage = "Username field is required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Username field is 40 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Username field is 1 character.")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Email field is 100 characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for the Email field is 3 characters.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        [PasswordPropertyText]
        [Required(ErrorMessage = "Password field is required.")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Password field is 150 characters.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Password field is 6 characters.")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's confirmation password.
        /// </summary>
        [PasswordPropertyText]
        [Required(ErrorMessage = "Confirm Password field is required.")]
        [Compare("Password", ErrorMessage = "Confirm Password does not match with Password.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Confirm Password field is 150 characters.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Confirm Password field is 6 characters.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
