using RPSLS.Models;
using Microsoft.EntityFrameworkCore;

namespace RPSLS.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Player> Players { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choice>()
                .ToTable(nameof(Choice));

            modelBuilder.Entity<Computer>()
                .ToTable(nameof(Computer));

            modelBuilder.Entity<Player>()
                .ToTable(nameof(Player));
        }
    }
}
