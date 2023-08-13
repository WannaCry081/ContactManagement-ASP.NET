using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    [Table("Users")]
    public class User
    {   
        [Key]
        public int Id { get; set; }
        
        [StringLength(40)]
        public string FirstName { get; set; } = string.Empty;
        
        [StringLength(40)]
        public string LastName { get; set; } = string.Empty;
        
        [StringLength(40)]
        public string UserName { get; set; } = string.Empty;
        
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(150)]
        public string PasswordHash { get; set; } = string.Empty;
        
        [StringLength(150)]
        public string PasswordSalt { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}