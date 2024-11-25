using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Model;

namespace Repository.Repositories.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly MyDbContext _context;
        public ProductRepository(MyDbContext context, DbSet<Product> dbSet) : base(context, dbSet) {
            _context = context;
        }

        public Product GetById(int productId)
        {
            return _context.Set<Product>().Find(productId);
        }

        public bool UpdateProductStock(int productId, int quantity)
        {
            var product = _context.Set<Product>().Find(productId);

            if (product == null || product.Stock + quantity < 0)
                return false;

            product.Stock += quantity;
            product.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
            return true;
        }

        public bool ProductExists(int productId)
        {
            return _context.Set<Product>().Any(p => p.Id == productId);
        }

    }
}
