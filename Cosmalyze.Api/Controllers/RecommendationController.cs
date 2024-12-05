using Cosmalyze.Api.Data;
using Cosmalyze.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cosmalyze.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly CosmalyzeDbContext _context;

        public RecommendationController(CosmalyzeDbContext context)
        {
            _context = context;
        }

        // GET: api/Recommendation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetRecommendedProducts()
        {
            // Fetch all products from the database
            var products = await _context.Products.ToListAsync();

            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }

            // Randomize the products in memory
            var random = new Random();
            var recommendedProducts = products.OrderBy(p => random.Next()).Take(3).ToList();

            // Map to ProductDto
            var recommendedProductDtos = recommendedProducts.Select(p => new ProductDto
            {
                Id = p.Id,
                BrandId = p.BrandId,
                Brand = p.Brand,
                Name = p.Name,
                Price = p.Price,
                PriceSign = p.PriceSign,
                Currency = p.Currency,
                ImageLink = p.ImageLink,
                ProductLink = p.ProductLink,
                WebsiteLink = p.WebsiteLink,
                Description = p.Description,
                Category = p.Category,
                ProductType = p.ProductType,
                TagList = p.TagList,
                UPC = p.UPC
            }).ToList();

            return Ok(recommendedProductDtos);
        }
    }
}
