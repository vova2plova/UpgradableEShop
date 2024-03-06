using eShop.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop
{
    public class EShopDbContext : DbContext
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DiscountPolicy> DiscountPolicies { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; } 

        public EShopDbContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
