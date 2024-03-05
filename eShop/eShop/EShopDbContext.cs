using eShop.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop
{
    public class EShopDbContext : DbContext
    {
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<CatalogItem> CatalogItems { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<DiscountPolicy> DiscountPolicies { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; } 
    }
}
