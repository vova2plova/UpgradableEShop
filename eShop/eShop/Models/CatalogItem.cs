namespace eShop.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public required Item Item { get; set; }
        public int AvailableStock { get; set; }
    }
}
