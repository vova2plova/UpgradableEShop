namespace eShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } 
        public List<Item>? Items { get; set; }
        public DiscountPolicy? DiscountPolicy { get; set; }
    }
}
