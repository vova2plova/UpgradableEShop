using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.Commands.Delete
{
    internal class DeleteItemCommand : IRequest<Result>
    {
        public string Id { get; set; }
    }
}
