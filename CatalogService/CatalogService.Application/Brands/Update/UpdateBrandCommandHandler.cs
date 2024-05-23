using CatalogService.Application.UOW;
using CatalogService.Domain;
using MongoDB.Bson;

namespace CatalogService.Application.Brands.Update
{
    public class SaveBrandCommandHandler(
        UnitOfWork unitOfWork
        ) : IRequestHandler<SaveBrandCommand, Result>
    {
        public async Task<Result> Handle(SaveBrandCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.Brands.SaveAsync(new Brand
            {
                Id = new ObjectId(request.Id),
                DisplayName = request.DisplayName,
                Logo = request.Logo
            }, cancellationToken);
            return Result.Ok();
        }
    }
}
