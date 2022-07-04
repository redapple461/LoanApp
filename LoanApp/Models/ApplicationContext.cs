using Microsoft.EntityFrameworkCore;

namespace LoanApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
