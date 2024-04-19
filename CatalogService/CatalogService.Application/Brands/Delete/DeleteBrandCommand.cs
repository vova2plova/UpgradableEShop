using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace CatalogService.Application.Brands.Delete
{
    public record DeleteBrandCommand : IRequest<Result>
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }
    }
}
