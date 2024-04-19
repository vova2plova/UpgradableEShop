using CatalogService.Application.UOW;
using CatalogService.Domain;

namespace CatalogService.Application.Items.Get
{
    public class GetItemsQueryHandler(
        UnitOfWork unitOfWork
        ) : IRequestHandler<GetItemsQuery, Result<IEnumerable<Item>>>
    {
        public async Task<Result<IEnumerable<Item>>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var items = (await unitOfWork.Items.GetListAsync(cancellationToken)).Take(50);
            return Result.Ok(items);
        }
    }
}
