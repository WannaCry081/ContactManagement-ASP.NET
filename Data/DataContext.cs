using Microsoft.EntityFrameworkCore;
using backend.Entities;

namespace backend.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<User> Users => Set<User>();

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Contact> Contacts => Set<Contact>();
    }
}