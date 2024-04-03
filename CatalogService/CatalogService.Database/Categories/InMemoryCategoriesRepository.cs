using CatalogService.Application.UOW;
using CatalogService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Database.Categories
{
    public class InMemoryCategoriesRepository : IRepository<Category>
    {
        public Task AddAsync(IEnumerable<Category> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IEnumerable<Category> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Category>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<Category> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
