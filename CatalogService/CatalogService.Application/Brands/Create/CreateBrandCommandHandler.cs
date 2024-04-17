
using CatalogService.Application.UOW;
using CatalogService.Domain;

namespace CatalogService.Application.Brands.Create
{
    public class CreateBrandCommandHandler(UnitOfWork unitOfWork) : IRequestHandler<CreateBrandCommand, Result>
    {
        public async Task<Result> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.Brands.CreateAsync(  new Brand
            {
                DisplayName = request.DisplayName,
                Logo = request.Logo
            }, cancellationToken);
            return Result.Ok();
        }
    }
}
