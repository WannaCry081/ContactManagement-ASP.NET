using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.AuthModels
{
    /// <summary>
    /// Data model for user sign-in.
    /// </summary>
    public class SignInModel
    {
        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        [Required(ErrorMessage = "Email field is required.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Email field is 100 characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for the Email field is 3 characters.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        [PasswordPropertyText]
        [Required(ErrorMessage = "Password field is required.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Password field is 150 characters.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Password field is 6 characters.")]
        public string Password { get; set; } = string.Empty;
    }
}
