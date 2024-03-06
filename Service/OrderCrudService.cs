using WholeSaler.Entity;
using WholeSaler.IRepository;
using WholeSaler.IService;

namespace WholeSaler.Service
{
    public class OrderCrudService : IOrderCrudService
    {
        private readonly IOrderRepository _repository;
        private readonly IUserContextService _userContextService;
        public OrderCrudService(IOrderRepository repository, IUserContextService userContextService)
        {
            _repository = repository;
            _userContextService = userContextService;
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Order>> FindAll()
        {
            IEnumerable<Order> orders;
            var hasManager = await _userContextService.IsUserManager();
            if (hasManager)
            {
                orders = await _repository.FindAll();
            }
            else
            {
                var user = await _userContextService.GetUser();
                orders = await _repository.FindByUser(user);
            }
            return orders;
        }
        public async Task<Order> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task Insert(Order entity)
        {
            await _repository.Insert(entity);
        }

        public async Task Update(long id, Order entity)
        {
            var updatedEntity = await _repository.GetById(id);
            updatedEntity.Status=entity.Status;
            await _repository.Update(entity);
        }
        public async Task<Order> GetOrderWithAssortment(long id)
        {
            return await _repository.GetOrderWithAssortment(id);
        }

        public async Task<IEnumerable<Order>> FindByUser(User user)
        {
            return await _repository.FindByUser(user);
        }
    }
}
