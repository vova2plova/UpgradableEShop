using CatalogService.Domain;

namespace CatalogService.Application.Brands.Get
{
    public record GetBrandsQuery : IRequest<Result<IEnumerable<Brand>>>
    {
        public int Page { get; init; } = 0;
        public int Count { get; init; } = 3;
    }
}
