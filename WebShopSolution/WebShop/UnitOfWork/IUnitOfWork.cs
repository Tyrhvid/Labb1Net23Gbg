using Repository.Repositories;
using Repository.Repositories.Products;

namespace WebShop.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        int Complete();
    }
}
