﻿
using CatalogService.Application.UOW;
using CatalogService.Domain;
using MongoDB.Bson;

namespace CatalogService.Application.Brands.Update
{
    public class UpdateBrandCommandHandler(
        UnitOfWork unitOfWork
        ) : IRequestHandler<UpdateBrandCommand, Result>
    {
        public async Task<Result> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.Brands.UpdateAsync(new Brand
            {
                Id = new ObjectId(request.Id),
                DisplayName = request.DisplayName,
                Logo = request.Logo
            }, cancellationToken);
            return Result.Ok();
        }
    }
}
