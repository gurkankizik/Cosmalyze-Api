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
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasKey(b => b.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            SeedBrands(modelBuilder);
        }

        private void SeedBrands(ModelBuilder modelBuilder)
        {
            //var brands = JsonHelper.ReadBrandsFromJson("Brands.json");

            //foreach (var brand in brands)
            //{
            //    modelBuilder.Entity<Brand>().HasData(brand);
            //}

            //var products = JsonHelper.ReadProductsFromJson("Products.json");

            //foreach (var product in products)
            //{
            //    modelBuilder.Entity<Product>().HasData(product);
            //}
        }
    }
}