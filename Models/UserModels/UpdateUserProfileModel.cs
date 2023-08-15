using System.ComponentModel.DataAnnotations;

namespace backend.Models.UserModels
{
    /// <summary>
    /// Model for updating user profile information.
    /// </summary>
    public class UpdateUserProfileModel
    {
        /// <summary>
        /// Gets or sets the updated first name of the user.
        /// </summary>
        [Required(ErrorMessage = "First Name field is required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the First Name field is 40 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the First Name field is 1 character.")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updated last name of the user.
        /// </summary>
        [Required(ErrorMessage = "Last Name field is required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Last Name field is 40 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Last Name field is 1 character.")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updated username of the user.
        /// </summary>
        [Required(ErrorMessage = "Username field is required.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Username field is 40 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Username field is 1 character.")]
        public string UserName { get; set; } = string.Empty;
    }
}
