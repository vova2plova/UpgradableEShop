using CatalogService.Application.UOW;
using CatalogService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.Queries.GetById
{
    internal class GetItemByIdQueryHandler(
        UnitOfWork unitOfWork
        ) : IRequestHandler<GetItemByIdQuery, Result<Item>>
    {
        public async Task<Result<Item>> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var items = (await unitOfWork.Items.GetByIdAsync(request.Id, cancellationToken));
            return Result.Ok(items);
        }
    }
}
