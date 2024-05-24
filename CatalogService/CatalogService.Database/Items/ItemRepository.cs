using CatalogService.Application.UOW;
using CatalogService.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CatalogService.Database.Items
{
    public class ItemRepository : IRepository<Item>
    {
        readonly IMongoCollection<Item> Items;
        public ItemRepository() 
        {
            // Test Database
            var connString = "mongodb://localhost:27017";
            // Main Database
            // var connString = "mongodb://eshop_user:password@mongo:27017";
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

        public async Task CreateAsync(Item item, CancellationToken cancellationToken)
        {
            await Items.InsertOneAsync(item, null,  cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", new ObjectId(id) } };
            await Items.DeleteOneAsync(filter, cancellationToken);
        }

        public async Task SaveAsync(Item item, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", new ObjectId(item.Id.ToString()) } };
            await Items.UpdateOneAsync(filter, null, null,cancellationToken);
        }

       
    }
}
