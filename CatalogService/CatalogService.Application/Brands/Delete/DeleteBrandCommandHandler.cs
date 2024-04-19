
using CatalogService.Application.UOW;

namespace CatalogService.Application.Brands.Delete
{
    public class DeleteBrandCommandHandler(UnitOfWork unitOfWork) : IRequestHandler<DeleteBrandCommand, Result>
    {
        public async Task<Result> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var existedBrand = await unitOfWork.Brands.GetByIdAsync(request.Id, cancellationToken);

            if (existedBrand is null)
                return Result.Ok();

            await unitOfWork.Brands.DeleteAsync(request.Id, cancellationToken);
            return Result.Ok();
        }
    }
}
