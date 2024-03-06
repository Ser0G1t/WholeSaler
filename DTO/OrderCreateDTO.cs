using WholeSaler.Entity;
using WholeSaler.Enum;

namespace WholeSaler.DTO
{
    public record OrderCreateDTO
    {
        public User User { get; set; }
        public OrderStatus Status { get; set; }
    }
}
