using CatalogService.Application.UOW;
using CatalogService.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CatalogService.Database.Items
{
    public class ItemRepository : IRepository<Item>
    {
        IMongoCollection<Item> Items;
        public ItemRepository() 
        {
            var connString = "mongodb://eshop_user:password@mongo:27017";
            var client = new MongoClient(connString);
            Items = client.GetDatabase("EshopCatalogDatabase").GetCollection<Item>("Items");
        }

        public async Task<IEnumerable<Item>> GetListAsync(CancellationToken cancellationToken)
        {
            return await Items.AsQueryable().ToListAsync(cancellationToken);
        }
        public async Task<Item> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", new ObjectId(id) } };
            return await(await Items.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task CreateAsync(Item objects, CancellationToken cancellationToken)
        {
            await Items.InsertOneAsync(objects, null, cancellationToken);
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Item objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(string id, BsonDocument fieldsToUpdate, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", new ObjectId(id) } };
            await Items.UpdateOneAsync(filter, fieldsToUpdate, null, cancellationToken);
        }

       
    }
}
