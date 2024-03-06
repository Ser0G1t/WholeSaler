using WholeSaler.Entity;
using WholeSaler.Enum;
using WholeSaler.IRepository;
using WholeSaler.IService;

namespace WholeSaler.Facade
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IAssortmentRepository _assortmentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserContextService _userContextService;
        private readonly IInvoiceService _invoiceService;

        public OrderFacade(IAssortmentRepository assortmentRepository, IOrderRepository orderRepository, IUserContextService userContextService, IInvoiceService invoiceService)
        {
            _assortmentRepository = assortmentRepository;
            _orderRepository = orderRepository;
            _userContextService = userContextService;
            _invoiceService = invoiceService;
        }
        public async Task AddAssortmentToOrder(long AssortmentId)
        {
            var assortment = await _assortmentRepository.GetById(AssortmentId);
            var order = await CreateOrGetOrder();
            order.Assortments.Add(assortment);
            await _orderRepository.Update(order);
        }
        public async Task FinalizeOrder()
        {
            var user = await _userContextService.GetUser();
            var orders = await _orderRepository.FindByUser(user);
            var order = orders.Single(order => order.Status == OrderStatus.OPEN);
            order.Status = OrderStatus.CLOSED;
            await _orderRepository.Update(order);
            await _invoiceService.GenerateInvoice(order);
        }
        private async Task<Order> CreateOrGetOrder()
        {
            var user = await _userContextService.GetUser();
            var orders = await _orderRepository.FindByUser(user);
            if (orders.Any(el => el.Status == OrderStatus.OPEN))
            {
                return orders.First();
            }
            var order = new Order()
            {
                User = user
            };
            await _orderRepository.Insert(order);
            return order;
        }
    }
}
