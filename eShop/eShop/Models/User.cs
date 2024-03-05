namespace eShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string Email { get; set; }
        public List<Order>? Orders { get; set; }
        public Basket? Basket { get; set; }
    }
}
