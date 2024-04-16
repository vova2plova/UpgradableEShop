
using CatalogService.Application.UOW;

namespace CatalogService.Application.Brands.Delete
{
    public class DeleteBrandCommandHandler(UnitOfWork unitOfWork) : IRequestHandler<DeleteBrandCommand, Result>
    {
        public async Task<Result> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var allBrands = await unitOfWork.Brands.GetAsync(cancellationToken);
            var existingBrand = allBrands.FirstOrDefault(b => b.Id == request.BrandId);

            await unitOfWork.Brands.DeleteAsync(existingBrand, cancellationToken);
            return Result.Ok();
        }
    }
}
