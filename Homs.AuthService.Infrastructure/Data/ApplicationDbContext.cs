using Homs.AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homs.AuthService.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entities for PostgreSQL
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users"); // Lowercase table name convention in PostgreSQL
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Username).HasColumnName("username").IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).HasColumnName("email").IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).HasColumnName("password_hash").IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                // Add index for email
                entity.HasIndex(e => e.Email).IsUnique();
                // Add index for username
                entity.HasIndex(e => e.Username).IsUnique();
            });
        }
    }
}