using CatalogService.Domain;

namespace CatalogService.Application.Items.Get
{
    public class GetItemsQuery : IRequest<Result<IEnumerable<Item>>>
    {
        public int Page { get; init; } = 0;
        public int Count { get; init; } = 5;
    }
}
