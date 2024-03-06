namespace WholeSaler.Entity
{
    public class Palette : CoreEntity
    {
        public long PaletteId {  get; set; }
        public List<Assortment> Assortments { get; set; }
        public Palette() {
            Assortments = new List<Assortment>();
        }
    }
}
