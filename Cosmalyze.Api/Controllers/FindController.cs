using Cosmalyze.Api.Data;
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
        public async Task<ActionResult<IEnumerable<object>>> Search([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name parameter is required.");
            }

            var products = await _context.Products
                .Where(p => p.Name.Contains(name) || p.Brand.Contains(name))
                .ToListAsync();

            var brands = await _context.Brands
                .Where(b => b.Name.Contains(name))
                .ToListAsync();

            var results = new List<object>();
            results.AddRange(products);
            results.AddRange(brands);

            if (results.Count == 0)
            {
                return NotFound();
            }

            return Ok(results);
        }
    }
}