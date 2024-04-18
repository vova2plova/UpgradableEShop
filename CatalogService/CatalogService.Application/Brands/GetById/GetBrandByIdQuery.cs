using CatalogService.Domain;
using MongoDB.Bson;

namespace CatalogService.Application.Brands.GetById
{
    public record GetBrandByIdQuery : IRequest<Result<Brand>>
    {
        public string Id { get; init; }
    }
}
