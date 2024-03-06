using WholeSaler.Entity;

namespace WholeSaler.IRepository
{
    public interface IOrderRepository : ICoreRepository<Order>
    {
        Task<IEnumerable<Order>> FindByUser(User user);
        Task<Order> GetOrderWithAssortment(long id);
    }
}
