using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.UserModels
{
    /// <summary>
    /// Model for updating user's password.
    /// </summary>
    public class UpdateUserPasswordModel
    {
        /// <summary>
        /// Gets or sets the old password of the user.
        /// </summary>
        [PasswordPropertyText]
        [Required(ErrorMessage = "Old Password field is required.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Old Password field is 6 characters.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Old Password field is 150 characters.")]
        public string OldPassword { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the new password of the user.
        /// </summary>
        [PasswordPropertyText]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password does not match with Confirm New Password.")]
        [Required(ErrorMessage = "New Password field is required.")]
        [MinLength(6, ErrorMessage = "Minimum length for the New Password field is 6 characters.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the New Password field is 150 characters.")]
        public string NewPassword { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the confirmation of the new password of the user.
        /// </summary>
        [PasswordPropertyText]
        [Compare("NewPassword", ErrorMessage = "Confirm New Password does not match with New Password.")]
        [Required(ErrorMessage = "Confirm New Password field is required.")]
        [MinLength(6, ErrorMessage = "Minimum length for the Confirm New Password field is 6 characters.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Confirm New Password field is 150 characters.")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
