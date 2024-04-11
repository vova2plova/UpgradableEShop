using CatalogService.Domain;

namespace CatalogService.Application.Brands.Get
{
    public record GetBrandsCommand : IRequest<Result<IEnumerable<Brand>>>
    {
        public int Page { get; set; }
        public int Count { get; set; }
    }
}
