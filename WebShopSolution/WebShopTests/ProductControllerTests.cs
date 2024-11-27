using Moq;
using Microsoft.AspNetCore.Mvc;
using WebShop.Controllers;
using WebShop.Models;
using WebShop.UnitOfWork;
using WebShop.Logging;
using WebShop.Repositories;

namespace WebShop.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IRepository<Product>> _mockProductRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ILogger> _mockLogger;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockProductRepository = new Mock<IRepository<Product>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger>();

            _mockUnitOfWork.Setup(u => u.Products).Returns(_mockProductRepository.Object);
            _controller = new ProductController(_mockUnitOfWork.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetProducts_ReturnsOkResult()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product1" },
                new Product { Id = 2, Name = "Product2" }
            };

            _mockProductRepository.Setup(repo => repo.GetAll()).Returns(products);

            // Act
            var result = _controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result); // Justera här för att hantera ActionResult
            var returnProducts = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(2, returnProducts.Count);
        }

        [Fact]
        public void AddProduct_ReturnsOkResult_AndLogsMessage()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product1" };

            // Act
            var result = _controller.AddProduct(product);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockProductRepository.Verify(repo => repo.Add(product), Times.Once);
            _mockUnitOfWork.Verify(u => u.Complete(), Times.Once);
            _mockUnitOfWork.Verify(u => u.NotifyProductAdded(product), Times.Once);
            _mockLogger.Verify(l => l.Log(It.Is<string>(s => s.Contains("Product added: Product1"))), Times.Once);
        }
    }
}
