using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Items.CreateItem
{
    /// <summary>
    /// Обработчик команды создания товара
    /// </summary>
    internal class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Result>
    {
        /// <inheritdoc/>
        public Task<Result> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Result.Ok());
        }
    }
}
