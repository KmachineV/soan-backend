using Microsoft.EntityFrameworkCore;
using soan_backend.Domain;

namespace soan_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User").HasIndex(e => e.Email).IsUnique().HasName("EmailIndex");

            builder.Seed();

        }
    }
}

