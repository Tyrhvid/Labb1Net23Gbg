using WebShop.Data;
using WebShop.Models;
using WebShop.Notifications;
using WebShop.Repositories;
using WebShop.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyDbContext _context;
    private readonly ProductSubject _productSubject;

    public UnitOfWork(MyDbContext context)
    {
        _context = context;
        Products = new Repository<Product>(_context);
        _productSubject = new ProductSubject();
        _productSubject.Attach(new EmailNotification());
    }

    public IRepository<Product> Products { get; private set; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void NotifyProductAdded(Product product)
    {
        _productSubject.Notify(product);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}