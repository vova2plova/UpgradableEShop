using System.Text.Json.Serialization;

namespace CatalogService.Controllers.Brands.Dto
{
    public record BrandDto
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }
        [JsonPropertyName("logo")]
        public string Logo { get; init; }
    }
}
