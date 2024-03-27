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

            modelBuilder.Entity<Article>()
                .HasMany(e => e.References)
                .WithMany(e => e.Articles)
                .UsingEntity("ArticleReference");

            modelBuilder.Entity<Article>()
              .HasOne(c => c.User)
              .WithMany(n => n.Article)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ArticleComment>()
             .HasOne(c => c.User)
             .WithMany(n => n.ArticleComment)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ArticleComment>()
            .HasOne(c => c.Article)
            .WithMany(n => n.ArticleComment)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Portfolio>()
               .HasOne(c => c.Customer)
               .WithMany(n => n.Portfolio)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Portfolio>()
              .HasOne(c => c.Reference)
              .WithMany(n => n.Portfolio)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PortfolioImage>()
              .HasOne(c => c.Portfolio)
              .WithMany(n => n.PortfolioImage)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Testimonial>()
             .HasOne(c => c.Customer)
             .WithMany(n => n.Testimonial)
             .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleComment> ArticleComment { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Faq> Faq { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<PortfolioImage> PortfolioImage { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
        public DbSet<LoginAttempt> LoginAttempt { get; set; }
        public DbSet<PasswordReset> PasswordReset { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserNotification> UserNotification { get; set; }
        public DbSet<UserVerification> UserVerification { get; set; }

    }
}
