using System.ComponentModel.DataAnnotations;

namespace backend.Models.UserModels
{
    public class UpdateUserProfileModel
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
    }
}