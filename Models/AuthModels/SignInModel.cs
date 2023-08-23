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
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email Address must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        [PasswordPropertyText]
        [Required(ErrorMessage = "Password field is required.")]
        [StringLength(150, ErrorMessage = "Password must be between {2} and {1} characters long", MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }
}
