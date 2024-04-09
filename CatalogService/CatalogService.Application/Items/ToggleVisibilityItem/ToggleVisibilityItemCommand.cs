using System.Text.Json.Serialization;

namespace CatalogService.Application.Items.ToggleVisibilityItem
{
    public record ToggleVisibilityItemCommand : IRequest<Result>
    {
        [JsonPropertyName("itemId")]
        public int ItemId { get; init; }
    }
}
