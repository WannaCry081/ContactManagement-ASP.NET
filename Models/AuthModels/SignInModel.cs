using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.AuthModels
{
    /// <summary>
    /// 
    /// </summary>
    public class SignInModel
    {
        /// <summary>
        /// 
        /// </summary>
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        [Required(ErrorMessage = "Email field is Required.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Email field is 100 Characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for the Email field is 3 Characters.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [PasswordPropertyText]
        [Required(ErrorMessage = "Password field is Required.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Password field is 150 Characters.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Password field is 6 Characters.")]
        public string Password { get; set; } = string.Empty;
    }
}