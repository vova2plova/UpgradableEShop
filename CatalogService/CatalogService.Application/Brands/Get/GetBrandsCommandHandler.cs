
using CatalogService.Application.UOW;
using CatalogService.Domain;

namespace CatalogService.Application.Brands.Get
{
    public class GetBrandsCommandHandler : IRequestHandler<GetBrandsCommand, Result<IEnumerable<Brand>>>
    {
        private readonly UnitOfWork _unitOfWork;
        public GetBrandsCommandHandler(UnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Brand>>> Handle(GetBrandsCommand request, CancellationToken cancellationToken)
        {
            //TODO PAGINATION + FILTRES
            var brands = (await _unitOfWork.Brands.GetAsync(cancellationToken)).Take(50);
            return Result.Ok(brands);
        }
    }
}
