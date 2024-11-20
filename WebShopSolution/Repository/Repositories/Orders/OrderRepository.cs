using Repository.Model;

namespace Repository.Repositories.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public bool ChangeOrderStatus(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
