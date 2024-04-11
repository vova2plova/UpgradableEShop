using CatalogService.Domain;

namespace CatalogService.Application.UOW
{
    /// <summary>
    /// Обхект для работы с получением / сохранением / обновлением и удалением всех данных. Так же фиксирует и коммитит изменения
    /// </summary>
    public class UnitOfWork
    {
        public IRepository<Item> Items { get; }
        public IRepository<Brand> Brands { get; }

        public UnitOfWork(IRepository<Item> items, IRepository<Brand> brands)
        {
            Items = items;
            Brands = brands;
        }
    }
}
