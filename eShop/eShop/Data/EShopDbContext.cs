using eShop.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data
{
    public class EShopDbContext : DbContext
    {
        public DbSet<DiscountPolicy> DiscountPolicies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public EShopDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
