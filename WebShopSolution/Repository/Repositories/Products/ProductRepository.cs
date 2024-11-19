using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Model;

namespace Repository.Repositories.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public bool UpdateProductStock(Product product, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
