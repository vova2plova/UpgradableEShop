using CatalogService.Application.UOW;

namespace CatalogService.Application.Items.ToggleVisibilityItem
{
    internal class ToggleVisibilityItemCommandHandler : IRequestHandler<ToggleVisibilityItemCommand, Result>
    {
        private readonly UnitOfWork _unitOfWork;

        public ToggleVisibilityItemCommandHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(ToggleVisibilityItemCommand request, CancellationToken cancellationToken)
        {
            // TODO specification
            var allItem = await _unitOfWork.Items.GetAsync(cancellationToken);

            var existingItem = allItem.FirstOrDefault(i => i.Id == request.ItemId);

            if (existingItem is null)
                return Result.Fail("Товара с выбранным идентификтором не существует");

            existingItem.ToggleVisibility();
            await _unitOfWork.Items.UpdateAsync(new[] { existingItem }, cancellationToken);
            
            return Result.Ok();
        }
    }
}
