
using CatalogService.Application.UOW;
using CatalogService.Domain;

namespace CatalogService.Application.Brands.Queries.Get
{
    public class GetBrandsQueryHandler(UnitOfWork unitOfWork) : IRequestHandler<GetBrandsQuery, Result<IEnumerable<Brand>>>
    {
        public async Task<Result<IEnumerable<Brand>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            //TODO PAGINATION + FILTRES
            var brands = (await unitOfWork.Brands.GetListAsync(cancellationToken)).Take(50);
            return Result.Ok(brands);
        }
    }
}
