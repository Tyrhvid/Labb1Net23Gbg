using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository.Model;
using WebShop.Controllers;
using WebShop.UnitOfWork;
using Xunit;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

public class ProductControllerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _controller = new ProductController(_mockUnitOfWork.Object, Mock.Of<ILogger<ProductController>>());
    }

    [Fact]
    public void AddProduct_ValidProduct_ReturnsCreatedResult()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Name = "Test Product",
            Price = 20,
            Stock = 10,
            CategoryId = 1
        };

        _mockUnitOfWork.Setup(uow => uow.Products.Add(It.IsAny<Product>()));
        _mockUnitOfWork.Setup(uow => uow.Complete());

        // Act
        var result = _controller.AddProduct(product);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedProduct = Assert.IsType<Product>(createdResult.Value);
        Assert.Equal(product.Name, returnedProduct.Name);
        Assert.Equal(product.Price, returnedProduct.Price);
        Assert.Equal(product.Stock, returnedProduct.Stock);
    }

    [Fact]
    public void AddProduct_InvalidProduct_ReturnsBadRequest()
    {
        // Arrange
        var product = new Product
        {
            Name = "", // Invalid name
            Price = -5, // Invalid price
            Stock = -1 // Invalid stock
        };

        // Act
        var result = _controller.AddProduct(product);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Product must have a valid name, price greater than zero, and non-negative stock.", badRequestResult.Value);
    }

    [Fact]
    public void GetProductById_ExistingId_ReturnsOkResultWithProduct()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Name = "Test Product",
            Price = 20.5m,
            Stock = 10,
            CategoryId = 1
        };

        _mockUnitOfWork.Setup(uow => uow.Products.GetById(1)).Returns(product);

        // Act
        var result = _controller.GetProductById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedProduct = Assert.IsType<Product>(okResult.Value);
        Assert.Equal(product.Id, returnedProduct.Id);
        Assert.Equal(product.Name, returnedProduct.Name);
        Assert.Equal(product.Price, returnedProduct.Price);
    }

    [Fact]
    public void GetProductById_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        _mockUnitOfWork.Setup(uow => uow.Products.GetById(1)).Returns((Product)null);

        // Act
        var result = _controller.GetProductById(1);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Product with ID 1 not found.", notFoundResult.Value);
    }
}
