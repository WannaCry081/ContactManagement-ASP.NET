namespace backend.Models.ContactModels
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserContactModel
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
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; } = string.Empty;
    }
}