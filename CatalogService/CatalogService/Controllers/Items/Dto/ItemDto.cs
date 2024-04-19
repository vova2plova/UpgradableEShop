using System.Text.Json.Serialization;

namespace CatalogService.Controllers.Items.Dto
{
    public class ItemDto
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }
        [JsonPropertyName("brandId")]
        public string BrandId { get; init; }
        [JsonPropertyName("categories")]
        public IReadOnlyCollection<string> Categories { get; init; }
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; init; }
        [JsonPropertyName("images")]
        public IReadOnlyCollection<string> Images { get; init; }
        [JsonPropertyName("characteristics")]
        public IReadOnlyDictionary<string, string> Characteristics { get; init; }
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get;init; }

    }
}
