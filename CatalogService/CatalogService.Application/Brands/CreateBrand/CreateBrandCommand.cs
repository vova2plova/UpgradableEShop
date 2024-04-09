using System.Text.Json.Serialization;

namespace CatalogService.Application.Brands.CreateBrand
{
    public record CreateBrandCommand : IRequest<Result>
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }
}
