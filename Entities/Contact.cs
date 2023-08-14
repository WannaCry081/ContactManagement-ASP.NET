using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Contacts")]
    public class Contact
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("Users")]
        public int? UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User? User { get; set; }

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
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        [StringLength(14)]
        public string PhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;   
    }
}