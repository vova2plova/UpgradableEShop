using System.Text.Json.Serialization;

namespace CatalogService.Application.Brands.Commands.Delete
{
    public record DeleteBrandCommand : IRequest<Result>
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }
    }
}
