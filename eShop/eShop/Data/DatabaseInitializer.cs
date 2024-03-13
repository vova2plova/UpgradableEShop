using eShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text;
using eShop.DataTransferObjects;

namespace eShop.Data
{
    public interface IDatabaseInitializer
    {
        void Initialize();
    }

    public class DatabaseInitializer(IDbContextFactory<EShopDbContext> dbContextFactory) : IDatabaseInitializer
    {
        public void Initialize()
        {
            var dbContext = dbContextFactory.CreateDbContext();
            dbContext.Database.EnsureCreated();

            if (dbContext.Items.Any())
                return;

            Item[] items = ReadItemsInitialFromDisk()
                .Select(i =>
                    new Item
                    {
                        Title = i.title,
                        Description = i.description,
                        Price = i.price,
                        DiscountPolicy = GetOrCreateDiscountPolicy(dbContext, i.discountPercentage),
                        Rating = i.rating,
                        Stock = i.stock,
                        Brand = GetOrCreateBrand(dbContext, i.brand),
                        Category = GetOrCreateCategory(dbContext, i.category),
                        Thumbnail = i.thumbnail,
                        Images = i.images,
                    })
                .ToArray();

            foreach (var item in items)
            {
                dbContext.Items.Add(item);
            }

            dbContext.SaveChanges();
        }

        private static DiscountPolicy GetOrCreateDiscountPolicy(EShopDbContext dbContext, decimal discountPersentage)
        {
            var discountPolicy = dbContext
                .DiscountPolicies
                .FirstOrDefault(c => c.Percentage == discountPersentage);
            if (discountPolicy == default)
            {
                discountPolicy = new DiscountPolicy { Percentage = discountPersentage };
                dbContext.DiscountPolicies.Add(discountPolicy);
                dbContext.SaveChanges();
            }

            return discountPolicy;
        }

        private static Category GetOrCreateCategory(EShopDbContext dbContext, string displayName)
        {
            var category = dbContext
                .Categories
                .FirstOrDefault(c => c.DisplayName == displayName);
            if (category == default)
            {
                category = new Category { DisplayName = displayName };
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
            }

            return category;
        }

        private static Brand GetOrCreateBrand(EShopDbContext dbContext, string displayName)
        {
            var brand = dbContext
                .Brands
                .FirstOrDefault(c => c.DisplayName == displayName);
            if (brand == default)
            {
                brand = new Brand { DisplayName = displayName };
                dbContext.Brands.Add(brand);
                dbContext.SaveChanges();
            }

            return brand;
        }

        public static IEnumerable<CreateItemDto> ReadItemsInitialFromDisk()
        {
            var pathToJson = Path.Combine("Data", "Items.json");
            var json = File.ReadAllText(pathToJson, Encoding.UTF8);
            var items = JsonSerializer.Deserialize<IEnumerable<CreateItemDto>>(json)
                ?? throw new InvalidOperationException("Json must be of type IEnumerable<Item>.");
            return items;
        }
    }
}
