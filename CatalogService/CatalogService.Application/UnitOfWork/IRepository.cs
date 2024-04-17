namespace CatalogService.Application.UOW
{
    /// <summary>
    /// Базовая абстракция всех репозиторией
    /// </summary>
    /// <typeparam name="T">Тип объекта, с которым работает репозиторий</typeparam>
    public interface IRepository<T>
    {
        Task<T> GetById(string id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetListAsync(CancellationToken cancellationToken);

        Task CreateAsync(T objects, CancellationToken cancellationToken);  
        Task DeleteAsync(string id, CancellationToken cancellationToken);  
        Task UpdateAsync(T objects, CancellationToken cancellationToken);  
        Task SaveAsync(T objects, CancellationToken cancellationToken);
    }
}
