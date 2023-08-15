using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    /// <summary>
    /// Entity class representing user data.
    /// </summary>
    [Table("Users")]
    public class User
    {   
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        [StringLength(40)]
        public string FirstName { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        [StringLength(40)]
        public string LastName { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [StringLength(40)]
        public string UserName { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the password hash of the user.
        /// </summary>
        [StringLength(150)]
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password salt of the user.
        /// </summary>
        [StringLength(150)]
        public string PasswordSalt { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the timestamp of when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the user was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the collection of contacts associated with the user.
        /// </summary>
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
