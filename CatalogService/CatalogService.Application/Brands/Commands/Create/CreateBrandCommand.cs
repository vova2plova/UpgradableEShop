using System.Text.Json.Serialization;

namespace CatalogService.Application.Brands.Commands.Create
{
    public record CreateBrandCommand : IRequest<Result>
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }
        [JsonPropertyName("logo")]
        public string? Logo { get; init; }
    }
}
