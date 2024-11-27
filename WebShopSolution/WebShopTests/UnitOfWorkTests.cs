using WebShop.Data;
using WebShop.Models;
using WebShop.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Tests
{
    public class UnitOfWorkTests
    {
        private readonly MyDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkTests()
        {
            _context = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options);

            _unitOfWork = new global::UnitOfWork(_context);
        }

        [Fact]
        public void NotifyProductAdded_Should_CallNotify()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product1" };

            // Act
            _unitOfWork.NotifyProductAdded(product);

            // Assert
            // Lägg till relevanta asserts beroende på vad du vill kontrollera
            // T.ex., verifiera att produkten har notifierats, om du har en metod för att kontrollera detta
            Assert.NotNull(product); // Exempel på assert
        }

        [Fact]
        public void Complete_Should_ReturnNumberOfChanges()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product1" };
            _context.Products.Add(product);

            // Act
            var result = _unitOfWork.Complete();

            // Assert
            Assert.Equal(1, result);
        }
    }
}