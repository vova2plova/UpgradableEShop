using CatalogService.Application.UOW;
using CatalogService.Domain;
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
        private readonly UnitOfWork _unitOfWork;
        public CreateItemCommandHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <inheritdoc/>
        public async Task<Result> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item(request.DisplayName, request.Price, request.BrandId, request.Categories, request.Thumbnail, request.IsVisible, request.Images, request.Characteristics);

            await _unitOfWork.Items.CreateAsync(item, cancellationToken);

            return Result.Ok();
        }
    }
}
