﻿
using CatalogService.Application.UOW;
using CatalogService.Domain;

namespace CatalogService.Application.Brands.Queries.GetById
{
    public class GetBrandByIdQueryHandler(
        UnitOfWork unitOfWork
        ) : IRequestHandler<GetBrandByIdQuery, Result<Brand>>
    {
        public async Task<Result<Brand>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await unitOfWork.Brands.GetByIdAsync(request.Id, cancellationToken);
            return Result.Ok(brand);
        }
    }
}
