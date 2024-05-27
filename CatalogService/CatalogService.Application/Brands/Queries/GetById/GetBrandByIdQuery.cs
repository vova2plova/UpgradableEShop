using CatalogService.Domain;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace CatalogService.Application.Brands.Queries.GetById
{
    public record GetBrandByIdQuery : IRequest<Result<Brand>>
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }
    }
}
