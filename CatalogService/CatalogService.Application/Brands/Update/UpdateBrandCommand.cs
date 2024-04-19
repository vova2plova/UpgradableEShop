﻿using CatalogService.Domain;
using System.Text.Json.Serialization;

namespace CatalogService.Application.Brands.Update
{
    public record UpdateBrandCommand : IRequest<Result>
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }
        [JsonPropertyName("logo")]
        public string Logo { get; init; }
    }
}
