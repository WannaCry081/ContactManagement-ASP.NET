using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.UserModels
{
    public class UpdateUserPasswordModel
    {
        [PasswordPropertyText]
        [Required(ErrorMessage = "Password field is Required.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Confirm Password field is 6 Characters.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Confirm Password field is 150 Characters.")]
        public string OldPassword { get; set; } = string.Empty;

        [PasswordPropertyText]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password does not match with Password.")]
        [Required(ErrorMessage = "Password field is Required.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Password field is 6 Characters.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Password field is 150 Characters.")]
        public string NewPassword { get; set; } = string.Empty;

        [PasswordPropertyText]
        [Compare("NewPassword", ErrorMessage = "Confirm New Password does not match with Password.")]
        [Required(ErrorMessage = "Confirm New Password field is Required.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Confirm New Password field is 6 Characters.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Confirm New Password field is 150 Characters.")]
        public string ConfirmNewPassword { get; set; } = string.Empty;   
    }
}