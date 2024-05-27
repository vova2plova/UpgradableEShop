using CatalogService.Application.UOW;
using CatalogService.Domain;
using FluentResults;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CatalogService.Database.Brands
{
    public class BrandRepository : IRepository<Brand>
    {
        readonly IMongoCollection<Brand> Brands;

        public BrandRepository() 
        {

            // Test Database
            var connString = "mongodb://localhost:27017";
            // Main Database
            // var connString = "mongodb://eshop_user:password@mongo:27017";
            var client = new MongoClient(connString);
            Brands = client.GetDatabase("EshopCatalogDatabase").GetCollection<Brand>("Brands");
        }

        public async Task<Brand> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", new ObjectId(id) } };
            return await (await Brands.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Brand>> GetListAsync(CancellationToken cancellationToken)
        {
            return await Brands.AsQueryable().ToListAsync(cancellationToken);
        }

        public async Task CreateAsync(Brand brand, CancellationToken cancellationToken)
        {
            await Brands.InsertOneAsync(brand, null, cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", new ObjectId(id) } };
            await Brands.DeleteOneAsync(filter, null, cancellationToken);
        }

        public async Task SaveAsync(Brand brand, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", brand.Id } };

            var BsonDocument = brand.ToBsonDocument();

            var updateSettings = new BsonDocument("$set", BsonDocument);

            await Brands.UpdateOneAsync(filter, updateSettings, null, cancellationToken);
        }
    }
}
