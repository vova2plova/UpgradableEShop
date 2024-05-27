using CatalogService.Application.UOW;
using CatalogService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.Commands.Delete
{
    internal class DeleteItemCommandHandler(
        UnitOfWork unitOfWork
        ) : IRequestHandler<DeleteItemCommand, Result>
    {
        public async Task<Result> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.Items.DeleteAsync(request.Id, cancellationToken);
            return Result.Ok();
        }
    }
}
