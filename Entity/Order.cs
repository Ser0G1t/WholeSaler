using WholeSaler.Enum;

namespace WholeSaler.Entity
{
    public class Order : CoreEntity
    {
        public long OrderId { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public List<Assortment> Assortments { get; set; }
        public Order() { 
            Assortments = new List<Assortment>();
            Status = OrderStatus.OPEN;
        }
    }
}
