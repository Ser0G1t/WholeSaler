namespace WholeSaler.Entity
{
    public class User : CoreEntity
    {
        public long UserId { get; set; }
        public string Email {  get; set; }
        public string Password { get; set; }
        public string CompanyName {  get; set; }
        public string NIP {  get; set; }
        public string Country {  get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string PostCode {  get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public List<Order> orders { get; set; }
        public User() { 
            orders = new List<Order>();
        }
    }
}
