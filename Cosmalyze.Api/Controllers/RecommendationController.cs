using Cosmalyze.Api.Data;
using Cosmalyze.Api.Models;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetRecommendedProducts()
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

            return Ok(recommendedProducts);
        }
    }
}
