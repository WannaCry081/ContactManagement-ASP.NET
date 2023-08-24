using Microsoft.EntityFrameworkCore;
using backend.Entities;

namespace backend.Data
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the `DataContext` class.
        /// </summary>
        /// <param name="options">The DbContext options.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the DbSet of users.
        /// </summary>
        public DbSet<User> Users => Set<User>();

        /// <summary>
        /// Gets or sets the DbSet of contacts.
        /// </summary>
        public DbSet<Contact> Contacts => Set<Contact>();

        /// <summary>
        /// Gets or sets the DbSet of user logs.
        /// </summary>
        public DbSet<UserLog> UserLogs => Set<UserLog>();

        /// <summary>
        /// Gets or sets the DbSet of contact logs.
        /// </summary>
        public DbSet<ContactLog> ContactLogs => Set<ContactLog>();
    }
}
