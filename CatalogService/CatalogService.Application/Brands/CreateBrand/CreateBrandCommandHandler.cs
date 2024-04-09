
using CatalogService.Application.UOW;
using CatalogService.Domain;
using System.Runtime.CompilerServices;

namespace CatalogService.Application.Brands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Result>
    {
        private readonly UnitOfWork _unitOfWork;
        public CreateBrandCommandHandler(UnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Brands.AddAsync([  new Brand
            {
                DisplayName = request.DisplayName,
                Logo = request.Logo
            }], cancellationToken);
            return Result.Ok();
        }
    }
}
