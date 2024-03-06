using Microsoft.EntityFrameworkCore;
using WholeSaler.Context;
using WholeSaler.Entity;
using WholeSaler.IRepository;

namespace WholeSaler.Repository
{
    public class OrderRepository : CoreRepository<Order>, IOrderRepository
    {
        public OrderRepository(CoreContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Order>> FindByUser(User user)
        {
            return await _context.orders.
               Where(order => order.User.UserId == user.UserId).
               Include(el => el.Assortments).
               Include(el=>el.User).
               ToListAsync();
        }
        public async override Task<Order> GetById(long id)
        {
            return await _context.orders.Include(order => order.User).FirstOrDefaultAsync(el => el.OrderId == id);
        }
        public async Task<Order> GetOrderWithAssortment(long id)
        {
            return await _context.orders.Include(order => order.Assortments).FirstOrDefaultAsync(el => el.OrderId == id);
        }
    }
}
