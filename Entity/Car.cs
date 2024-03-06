using WholeSaler.Enum;

namespace WholeSaler.Entity
{
    public class Car : CoreEntity
    {
        public long CarId { get; set; }
        public string Brand {  get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public CarType CarType { get; set; }
        public int PaletteCapacity { get; set; }

    }
}
