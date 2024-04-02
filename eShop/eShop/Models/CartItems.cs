namespace eShop.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public required Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
