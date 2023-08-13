using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.AuthModels
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "First Name field is Required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the First Name field is 40 Characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the First Name field is 1 Character.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name field is Required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Last Name field is 40 Characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Last Name field is 1 Character.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username field is Required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Username field is 40 Characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Username field is 1 Character.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email field is Required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Email field is 100 Characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for the Email field is 3 Characters.")]
        public string Email { get; set; } = string.Empty;

        [PasswordPropertyText]
        [Required(ErrorMessage = "Password field is Required.")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not Match.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Confirm Password field is 150 Characters.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Confirm Password field is 6 Characters.")]
        public string Password { get; set; } = string.Empty;

        [PasswordPropertyText]
        [Required(ErrorMessage = "Confirm Password field is Required.")]
        [Compare("Password", ErrorMessage = "Confirm Password does not match with Password.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Confirm Password field is 150 Characters.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Confirm Password field is 6 Characters.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}