using CatalogService.Application.UOW;
using CatalogService.Domain;
using System.Collections.Concurrent;

namespace CatalogService.Database.Items
{
    public class InMemoryItemsRepository : IRepository<Item>
    {
        private readonly ConcurrentDictionary<int, Item> _items = [];
        public Task AddAsync(IEnumerable<Item> objects, CancellationToken cancellationToken)
        {
            // TODO Race condition posible
            var getLastId = _items
                    .Keys
                    .OrderByDescending(r => r)
                    .FirstOrDefault() + 1;

            foreach (var item in objects)
            {
                item.Id = getLastId;
                _items.TryAdd(getLastId, item);
            }

            return Task.CompletedTask;

        }

        public Task DeleteAsync(IEnumerable<Item> objects, CancellationToken cancellationToken)
        {
            foreach (var item in objects)
            {
                _items.TryRemove(item.Id, out _);
            }

            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Item>> GetAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyCollection<Item>>(_items.Values.ToArray());
        }

        public Task UpdateAsync(IEnumerable<Item> objects, CancellationToken cancellationToken)
        {
            foreach (var item in objects)
            {
                if (!_items.TryGetValue(item.Id, out var existedAuction))
                    continue;

                existedAuction.UpdateDisplayName(item.DisplayName);
                existedAuction.UpdatePrice(item.Price);
                existedAuction.UpdateBrandId(item.BrandId);
                existedAuction.UpdateDiscountPolicy(item.DiscountPolicy);
                existedAuction.UpdateThumbnail(item.Thumbnail);
                existedAuction.UpdateImages(item.Images.ToList());
                existedAuction.UpdateCategories(item.Categories.ToList());
                existedAuction.UpdateCharacteristics(item.Characteristics.ToDictionary());
            }
            return Task.CompletedTask;
        }
    }
}
