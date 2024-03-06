using WholeSaler.Enum;

namespace WholeSaler.DTO
{
    public record AssortmentDTO
    {
        public long id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public AssortmentType type { get; set; }
    }
}
