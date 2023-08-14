using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Users")]
    public class User
    {   
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [StringLength(40)]
        public string FirstName { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        [StringLength(40)]
        public string LastName { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        [StringLength(40)]
        public string UserName { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        [StringLength(150)]
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [StringLength(150)]
        public string PasswordSalt { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}