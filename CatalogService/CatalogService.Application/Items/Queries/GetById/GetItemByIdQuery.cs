using CatalogService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.Queries.GetById
{
    public class GetItemByIdQuery : IRequest<Result<Item>>
    {
        public string Id { get; set; }
    }
}
