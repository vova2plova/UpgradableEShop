using CatalogService.Domain;
using System.Text.Json.Serialization;

namespace CatalogService.Application.Brands.Get
{
    public record GetBrandsQuery : IRequest<Result<IEnumerable<Brand>>>
    {
        [JsonPropertyName("page")]
        public int Page { get; init; } = 0;
        [JsonPropertyName("count")]
        public int Count { get; init; } = 3;
    }
}
