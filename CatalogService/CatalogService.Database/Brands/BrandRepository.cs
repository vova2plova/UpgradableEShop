using CatalogService.Application.UOW;
using CatalogService.Domain;
using FluentResults;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json.Serialization;

namespace CatalogService.Database.Brands
{
    public record BrandDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }
    public class BrandRepository : IRepository<Brand>
    {
        MongoClient client;
        public BrandRepository() 
        {
            var connString = "mongodb://localhost:27017";
            client = new MongoClient(connString);
        }

        public Task AddAsync(IEnumerable<Brand> objects, CancellationToken cancellationToken)
        {
            var Brands = client.GetDatabase("EshopCatalogDatabase").GetCollection<Brand>("Brands");
            Brands.InsertManyAsync(objects, null, cancellationToken);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(IEnumerable<Brand> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Brand>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<Brand> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
