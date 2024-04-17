using CatalogService.Application.UOW;
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
        
        public Task AddAsync(Item objects, CancellationToken cancellationToken)
        {
            return _items.InsertOneAsync(objects, null, cancellationToken);
        }

        public Task CreateAsync(Item objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Item objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Item>> GetAsync(CancellationToken cancellationToken)
        {
            return await _items.AsQueryable().ToListAsync(cancellationToken);
        }

        public Task<Item> GetById(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetListAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Item objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Item objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
