using System.Text.Json.Serialization;

namespace CatalogService.Application.Items.ToggleVisibility
{
    public record ToggleVisibilityCommand : IRequest<Result>
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }
    }
}
