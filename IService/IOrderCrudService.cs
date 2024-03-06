using WholeSaler.Entity;

namespace WholeSaler.IService
{
    public interface IOrderCrudService : ICoreCrudService<Order>
    {
        Task<Order> GetOrderWithAssortment(long id);
        Task<IEnumerable<Order>> FindByUser(User user);
    }
}
