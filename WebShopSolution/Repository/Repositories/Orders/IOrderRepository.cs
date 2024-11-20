using Repository.Model;

namespace Repository.Repositories.Orders;

public interface IOrderRepository : IRepository<Order>
{
    bool ChangeOrderStatus(Order order);
}