using CatalogService.Application.UOW;

namespace CatalogService.Application.Items.Commands.ToggleVisibility
{
    public class ToggleVisiblityCommandHandler(
        UnitOfWork unitOfWork
        ) : IRequestHandler<ToggleVisibilityCommand, Result>
    {
        public async Task<Result> Handle(ToggleVisibilityCommand request, CancellationToken cancellationToken)
        {
            var item = await unitOfWork.Items.GetByIdAsync(request.Id, cancellationToken);
            item.ToggleVisibility();

            await unitOfWork.Items.SaveAsync(item, cancellationToken);
            return Result.Ok();
        }
    }
}
