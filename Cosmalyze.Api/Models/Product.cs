namespace Cosmalyze.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
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
        public List<string>? TagList { get; set; } = new List<string>();
        public string? UPC { get; set; }
    }
}

