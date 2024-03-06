using System.Text.Json.Serialization;
using WholeSaler.Enum;

namespace WholeSaler.Entity
{
    public class Assortment : CoreEntity
    {
        public long AssortmentId { get; set; } 
        public string Name {  get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public AssortmentType type { get; set; }
        [JsonIgnore]
        public List<Order> orders { get; set; }
        [JsonIgnore]
        public List<Localisation> Localisations { get; set; }
        public Assortment()
        {
            orders = new List<Order>();
        }
        
    }
}
