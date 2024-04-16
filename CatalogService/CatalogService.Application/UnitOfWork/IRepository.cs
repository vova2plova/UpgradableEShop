namespace CatalogService.Application.UOW
{
    /// <summary>
    /// Базовая абстракция всех репозиторией
    /// </summary>
    /// <typeparam name="T">Тип объекта, с которым работает репозиторий</typeparam>
    public interface IRepository<T>
    {
        Task AddAsync(T objects, CancellationToken cancellationToken);  
        Task DeleteAsync(T objects, CancellationToken cancellationToken);  
        Task UpdateAsync(T objects, CancellationToken cancellationToken);  
        Task<IReadOnlyCollection<T>> GetAsync(CancellationToken cancellationToken);  
    }
}
