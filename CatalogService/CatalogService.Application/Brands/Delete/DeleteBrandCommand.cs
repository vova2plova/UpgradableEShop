using MongoDB.Bson;

namespace CatalogService.Application.Brands.Delete
{
    public record DeleteBrandCommand : IRequest<Result>
    {
        public ObjectId BrandId { get; init; }
    }
}
