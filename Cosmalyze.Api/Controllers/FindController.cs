using Cosmalyze.Api.Data;
using Cosmalyze.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cosmalyze.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindController : ControllerBase
    {
        private readonly CosmalyzeDbContext _context;

        public FindController(CosmalyzeDbContext context)
        {
            _context = context;
        }

        // GET: api/find
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAndBrands()
        {
            var products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/find/products
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] int? id, [FromQuery] string? name)
        {
            if (!id.HasValue && string.IsNullOrEmpty(name))
            {
                return BadRequest("At least one search parameter (id or name) must be provided.");
            }

            var query = _context.Products.Include(p => p.Brand).Include(p => p.Category).AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(p => p.Id == id.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            var products = await query.ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // GET: api/find/brands
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands([FromQuery] int? id, [FromQuery] string? name)
        {
            if (!id.HasValue && string.IsNullOrEmpty(name))
            {
                return BadRequest("At least one search parameter (id or name) must be provided.");
            }

            var query = _context.Brands.AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(b => b.Id == id.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(b => b.Name.Contains(name));
            }

            var brands = await query.ToListAsync();

            if (brands == null || brands.Count == 0)
            {
                return NotFound();
            }

            return Ok(brands);
        }
    }
}










