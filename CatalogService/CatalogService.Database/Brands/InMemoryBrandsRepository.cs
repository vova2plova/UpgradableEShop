using CatalogService.Application.UOW;
using CatalogService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Database.Brands
{
    public class InMemoryBrandsRepository : IRepository<Brand>
    {
        public Task AddAsync(IEnumerable<Brand> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IEnumerable<Brand> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Brand>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IEnumerable<Brand> objects, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
