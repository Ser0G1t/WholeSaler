namespace WholeSaler.Entity
{
    public class Localisation : CoreEntity
    {
        public long LocalisationId { get; set; }
        public string Name { get; set; }
        public List<Assortment> Assortments { get; set; }
        public Localisation()
        {
            Assortments = new List<Assortment>();
        }
    }
}
