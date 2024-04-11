﻿using CatalogService.Application.UOW;
using CatalogService.Domain;
using MongoDB.Driver;

namespace CatalogService.Database.Items
{
    public class ItemRepository : IRepository<Item>
    {
        IMongoCollection<Item> _items;
        public ItemRepository() 
        {
            var connString = "mongodb://localhost:27017";
            var client = new MongoClient(connString);
            _items = client.GetDatabase("EshopCatalogDatabase").GetCollection<Item>("Items");
        }
        
        public Task AddAsync(IEnumerable<Item> objects, CancellationToken cancellationToken)
        {
            return _items.InsertManyAsync(objects, null, cancellationToken);
        }

        public Task DeleteAsync(IEnumerable<Item> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Item>> GetAsync(CancellationToken cancellationToken)
        {
            return await _items.AsQueryable().ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(IEnumerable<Item> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
