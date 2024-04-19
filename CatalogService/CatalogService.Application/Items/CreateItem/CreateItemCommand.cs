using CatalogService.Domain;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.CreateItem
{
    public record CreateItemCommand : IRequest<Result>
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }
        [JsonPropertyName("description")]
        public string Description { get; init; }
        [JsonPropertyName("price")]
        public decimal Price { get; init; }
        [JsonPropertyName("brandId")]
        public string BrandId { get; init; }
        [JsonPropertyName("categories")]
        public List<string> Categories { get; init; }
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; init; }
        [JsonPropertyName("images")]
        public List<string>? Images { get; init; }
        [JsonPropertyName("characteristics")]
        public Dictionary<string,string>? Characteristics { get; init; }
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get; init; }

    }
}
