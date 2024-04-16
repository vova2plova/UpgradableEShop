using CatalogService.Application.UOW;
using CatalogService.Domain;
using FluentResults;
using MongoDB.Bson;
using MongoDB.Driver;
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

        public Task AddAsync(Brand objects, CancellationToken cancellationToken)
        {
            return Brands.InsertOneAsync(objects, null, cancellationToken);
        }

        public Task DeleteAsync(Brand objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Brand>> GetAsync(CancellationToken cancellationToken)
        {
            return await Brands.AsQueryable().ToListAsync();
        }

        public Task UpdateAsync(Brand objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
