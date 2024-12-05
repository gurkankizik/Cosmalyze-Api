using Cosmalyze.Api.Data;
using Cosmalyze.Api.DTOs;
using Cosmalyze.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cosmalyze.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CosmalyzeDbContext _context;

        public ProductsController(CosmalyzeDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            return await _context.Products
                .Select(p => new ProductDto
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
                })
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _context.Products
                .Select(p => new ProductDto
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
                })
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products/Search?name=productName
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProducts(string name)
        {
            var products = await _context.Products
                .Where(p => p.Name.Contains(name))
                .Select(p => new ProductDto
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
                })
                .ToListAsync();

            if (products == null || !products.Any())
            {
                return NotFound();
            }

            return products;
        }

        // GET: api/Products/SearchByUPC?upc=productUPC
        [HttpGet("SearchByUPC")]
        public async Task<ActionResult<ProductDto>> SearchProductByUPC(string upc)
        {
            var product = await _context.Products
                .Where(p => p.UPC == upc)
                .Select(p => new ProductDto
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
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDto productDto)
        {
            var product = new Product
            {
                BrandId = productDto.BrandId,
                Brand = productDto.Brand,
                Name = productDto.Name,
                Price = productDto.Price,
                PriceSign = productDto.PriceSign,
                Currency = productDto.Currency,
                ImageLink = productDto.ImageLink,
                ProductLink = productDto.ProductLink,
                WebsiteLink = productDto.WebsiteLink,
                Description = productDto.Description,
                Category = productDto.Category,
                ProductType = productDto.ProductType,
                TagList = productDto.TagList,
                UPC = productDto.UPC
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.BrandId = productDto.BrandId;
            product.Brand = productDto.Brand;
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.PriceSign = productDto.PriceSign;
            product.Currency = productDto.Currency;
            product.ImageLink = productDto.ImageLink;
            product.ProductLink = productDto.ProductLink;
            product.WebsiteLink = productDto.WebsiteLink;
            product.Description = productDto.Description;
            product.Category = productDto.Category;
            product.ProductType = productDto.ProductType;
            product.TagList = productDto.TagList;
            product.UPC = productDto.UPC;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
