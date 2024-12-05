using Cosmalyze.Api.Models;
using System.Text.Json;

namespace Cosmalyze.Api.Helpers
{
    public static class JsonHelper
    {
        public static List<Brand> ReadBrandsFromJson(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var brandsDictionary = JsonSerializer.Deserialize<Dictionary<string, BrandJsonModel>>(jsonString);

            var brands = new List<Brand>();
            if (brandsDictionary != null)
            {
                foreach (var kvp in brandsDictionary)
                {
                    var brandJson = kvp.Value;
                    brands.Add(new Brand
                    {
                        Id = int.Parse(brandJson.Id),
                        Name = kvp.Key,
                        IsAllVegan = bool.Parse(brandJson.IsAllVegan),
                        IsPartialVegan = bool.Parse(brandJson.IsPartialVegan),
                        IsCrueltyFree = bool.Parse(brandJson.IsCrueltyFree)
                    });
                }
            }
            return brands;
        }

        public static List<Product> ReadProductsFromJson(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var products = JsonSerializer.Deserialize<List<ProductJsonModel>>(jsonString);

            var productList = new List<Product>();

            if (products != null)
            {
                foreach (var productJson in products)
                {
                    var product = new Product
                    {
                        Id = int.Parse(productJson.Id),
                        Brand = productJson.Brand,
                        Name = productJson.Name,
                        Price = productJson.Price,
                        PriceSign = productJson.PriceSign,
                        Currency = productJson.Currency,
                        ImageLink = productJson.ImageLink,
                        ProductLink = productJson.ProductLink,
                        WebsiteLink = productJson.WebsiteLink,
                        Description = productJson.Description,
                        Category = productJson.Category,
                        ProductType = productJson.ProductType,
                        TagList = productJson.TagList?.Split(',').ToList(),
                        UPC = productJson.UPC
                    };
                    productList.Add(product);
                }
            }
            return productList;
        }
    }

    public class BrandJsonModel
    {
        public string Id { get; set; }
        public string IsAllVegan { get; set; }
        public string IsPartialVegan { get; set; }
        public string IsCrueltyFree { get; set; }
    }

    public class ProductJsonModel
    {
        public string Id { get; set; }
        public string? Brand { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? PriceSign { get; set; }
        public string? Currency { get; set; }
        public string? ImageLink { get; set; }
        public string? ProductLink { get; set; }
        public string? WebsiteLink { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ProductType { get; set; }
        public string? TagList { get; set; }
        public string? UPC { get; set; }
    }
}