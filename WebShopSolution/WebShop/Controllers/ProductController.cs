using Microsoft.AspNetCore.Mvc;
using WebShop.UnitOfWork;
using WebShop.Models;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Logging.ILogger _logger;

        public ProductController(IUnitOfWork unitOfWork, Logging.ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // Endpoint för att hämta alla produkter
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _unitOfWork.Products.GetAll();
            return Ok(products);
        }

        // Endpoint för att lägga till en ny produkt
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
            _unitOfWork.NotifyProductAdded(product);

            _logger.Log($"Product added: {product.Name}");

            return Ok();
        }
    }
}