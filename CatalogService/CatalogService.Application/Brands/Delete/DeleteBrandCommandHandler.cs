
using CatalogService.Application.UOW;

namespace CatalogService.Application.Brands.Delete
{
    public class DeleteBrandCommandHandler(UnitOfWork unitOfWork) : IRequestHandler<DeleteBrandCommand, Result>
    {
        public async Task<Result> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.Brands.DeleteAsync(request.BrandId.ToString(), cancellationToken);
            return Result.Ok();
        }
    }
}
