namespace eShop.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string MainImageUrl { get; set; }
        public required Brand Brand { get; set; }
        public required Category Category { get; set; }
        public List<string>? Images { get; set; }
        public DiscountPolicy? DiscountPolicy { get; set; }
        public bool? IsHidden { get; set; }
    }
}
