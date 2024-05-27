using CatalogService.Application.Validator;
using FluentResults;

namespace CatalogService.Application.Items.Commands.Create
{
    /// <summary>
    /// Валидатор команды создания товара
    /// </summary>
    public class CreateItemCommandValidator : IValidator<CreateItemCommand>
    {
        /// <inheritdoc/>
        public Result Validate(CreateItemCommand request)
        {
            if (request is null)
                return Result.Fail("Не удалось распознать данные");

            if (string.IsNullOrWhiteSpace(request.DisplayName))
                return Result.Fail("Передано пустое название товара");

            if (string.IsNullOrWhiteSpace(request.Thumbnail))
                return Result.Fail("Не удалось распознать главное изображение");

            if (request.Images.Count == 0)
                return Result.Fail("Изображения не добавлены");

            if (request.Categories.Count == 0)
                return Result.Fail("Не удалось распознать категории");

            if (request.Characteristics.Count == 0)
                return Result.Fail("Характеристики товара не заданы");

            if (request.Price <= 0)
                return Result.Fail("Цена не положительная");

            if (request.BrandId == default)
                return Result.Fail("Бренд не задан");

            return Result.Ok();
        }
    }
}
