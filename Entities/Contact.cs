using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Users")]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(40)]
        public string LastName { get; set; } = string.Empty;
        
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(14)]
        public string PhoneNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;   
    }
}