using WebShop.Models;
using WebShop.Repositories;

namespace WebShop.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        int Complete();
        void NotifyProductAdded(Product product);  // Lägg till denna rad
    }
}