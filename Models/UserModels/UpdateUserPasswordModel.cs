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
        [StringLength(150, ErrorMessage = "Old Password must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string OldPassword { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the new password of the user.
        /// </summary>
        [PasswordPropertyText]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password does not match with Confirm New Password.")]
        [StringLength(150, ErrorMessage = "New Password must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string NewPassword { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the confirmation of the new password of the user.
        /// </summary>
        [PasswordPropertyText]
        [Compare("NewPassword", ErrorMessage = "Confirm New Password does not match with New Password.")]
        [Required(ErrorMessage = "Confirm New Password field is required.")]
        [StringLength(150, ErrorMessage = "Confirm New Password must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
