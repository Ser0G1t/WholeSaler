namespace WholeSaler.Entity
{
    public class Transport : CoreEntity
    {
        public long TransportId { get; set; }
        public Car Car { get; set; }
        public List<Palette> Palettes { get; set; }
        public Transport() {
            Palettes= new List<Palette>();
        }
    }
}
