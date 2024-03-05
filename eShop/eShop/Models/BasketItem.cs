namespace eShop.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public required CatalogItem CatalogItem { get; set; }
        public int Quantity { get; set; }
    }
}
