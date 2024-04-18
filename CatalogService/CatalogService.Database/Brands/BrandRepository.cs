using CatalogService.Application.Brands.Create;
using CatalogService.Application.UOW;
using CatalogService.Domain;
using FluentResults;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CatalogService.Database.Brands
{
    public class BrandRepository : IRepository<Brand>
    {
        IMongoCollection<Brand> Brands { get; set; }

        public BrandRepository() 
        {
            var connString = "mongodb://localhost:27017";
            var client = new MongoClient(connString);
            Brands = client.GetDatabase("EshopCatalogDatabase").GetCollection<Brand>("Brands");
        }

        public async Task<Brand> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", new ObjectId(id) } };
            return await (await Brands.FindAsync(filter, null, cancellationToken)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Brand>> GetListAsync(CancellationToken cancellationToken)
        {
            return await Brands.AsQueryable().ToListAsync(cancellationToken);
        }

        public async Task CreateAsync(Brand objects, CancellationToken cancellationToken)
        {
            await Brands.InsertOneAsync(objects, null, cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", id } };
            await Brands.DeleteOneAsync(filter, null, cancellationToken);
        }

        public async Task UpdateAsync(Brand objects, CancellationToken cancellationToken)
        {
            var filter = new BsonDocument { { "_id", objects.Id } };
            var updateSettings = new BsonDocument("$set", new BsonDocument { 
                {
                    nameof(objects.DisplayName), objects.DisplayName
                },
                {
                    nameof(objects.Logo), objects.Logo
                }
            });
            await Brands.UpdateOneAsync(filter, updateSettings, null, cancellationToken);
        }

        public Task SaveAsync(Brand objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
