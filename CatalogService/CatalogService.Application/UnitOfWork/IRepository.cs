using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.UOW
{
    /// <summary>
    /// Базовая абстракция всех репозиторией
    /// </summary>
    /// <typeparam name="T">Тип объекта, с которым работает репозиторий</typeparam>
    public interface IRepository<T>
    {
        Task AddAsync(IEnumerable<T> objects, CancellationToken cancellationToken);  
        Task DeleteAsync(IEnumerable<T> objects, CancellationToken cancellationToken);  
        Task UpdateAsync(IEnumerable<T> objects, CancellationToken cancellationToken);  
        Task<IReadOnlyCollection<T>> GetAsync(CancellationToken cancellationToken);  
    }
}
