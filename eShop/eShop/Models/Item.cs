namespace eShop.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required DiscountPolicy DiscountPolicy { get; set; }
        public decimal Rating { get; set; }
        public int Stock { get; set; }
        public required Brand Brand { get; set; }
        public required Category Category { get; set; }
        public required string Thumbnail { get; set; }
        public List<string>? Images { get; set; }
    }
}
