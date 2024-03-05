namespace eShop.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public List<CatalogItem>? Items { get; set;}
    }
}
