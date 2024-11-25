using Microsoft.AspNetCore.Mvc;
using Repository.Model;
using WebShop.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IUnitOfWork unitOfWork, ILogger<ProductController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                _logger.LogWarning("AddProduct called with null product.");
                return BadRequest("Product is null.");
            }

            if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0 || product.Stock < 0)
            {
                _logger.LogWarning("AddProduct called with invalid product data.");
                return BadRequest("Product must have a valid name, price greater than zero, and non-negative stock.");
            }

            try
            {
                product.CreatedAt = DateTime.UtcNow;
                product.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.Products.Add(product);

                // Save changes
                _unitOfWork.Complete();

                _logger.LogInformation($"Product with ID {product.Id} added successfully.");
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a product.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _unitOfWork.Products.GetById(id);

            if (product == null)
            {
                _logger.LogWarning($"GetProductById called with invalid ID {id}.");
                return NotFound($"Product with ID {id} not found.");
            }

            return Ok(product);
        }
    }
}
