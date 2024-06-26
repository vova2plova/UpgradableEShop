﻿using MongoDB.Bson;

namespace CatalogService.Application.UOW
{
    /// <summary>
    /// Базовая абстракция всех репозиторией
    /// </summary>
    /// <typeparam name="T">Тип объекта, с которым работает репозиторий</typeparam>
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetListAsync(CancellationToken cancellationToken);

        Task CreateAsync(T src, CancellationToken cancellationToken);  
        Task DeleteAsync(string id, CancellationToken cancellationToken);  
        Task SaveAsync(T src, CancellationToken cancellationToken);
    }
}
