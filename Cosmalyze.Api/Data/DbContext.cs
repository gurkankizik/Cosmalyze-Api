using Cosmalyze.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Cosmalyze.Api.Data
{
    public class CosmalyzeDbContext : DbContext
    {
        public CosmalyzeDbContext(DbContextOptions<CosmalyzeDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany()
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            // Seed data
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Brand A", IsAllVegan = true, IsPartialVegan = false, IsCruelty = true },
                new Brand { Id = 2, Name = "Brand B", IsAllVegan = false, IsPartialVegan = true, IsCruelty = false }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category A" },
                new Category { Id = 2, Name = "Category B" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product A", Description = "Description A", CategoryId = 1, BrandId = 1, UPC = 123456, ImageUrl = "http://example.com/imageA.jpg" },
                new Product { Id = 2, Name = "Product B", Description = "Description B", CategoryId = 2, BrandId = 2, UPC = 789012, ImageUrl = "http://example.com/imageB.jpg" }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = "Test",
                    Username = "admin",
                    Password = "password",
                    Email = "admin@mail.com",
                    Phone = 123456789
                });

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    ProductId = 1,
                    UserId = 1,
                    RatingValue = 4.5f,
                    Comment = "Great product!"
                },
                new Review
                {
                    Id = 2,
                    ProductId = 2,
                    UserId = 1,
                    RatingValue = 3.0f,
                    Comment = "Average product."
                });
        }
    }
}
