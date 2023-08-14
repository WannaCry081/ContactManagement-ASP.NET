namespace backend.Models.UserModels
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserProfileModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}