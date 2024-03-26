using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;

namespace backend.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserNotification>()
              .HasOne(c => c.User)
              .WithMany(n => n.UserNotification)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserVerification>()
              .HasOne(c => c.User)
              .WithMany(n => n.UserVerification)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .UsingEntity("UserRoles");

        }

        public DbSet<LoginAttempt> LoginAttempt { get; set; }
        public DbSet<PasswordReset> PasswordReset { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserNotification> UserNotification { get; set; }
        public DbSet<UserVerification> UserVerification { get; set; }

    }
}
