
using CatalogService.Application.UOW;
using MongoDB.Bson;

namespace CatalogService.Application.Items.ToggleVisibility
{
    public class ToggleVisiblityCommandHandler(
        UnitOfWork unitOfWork
        ) : IRequestHandler<ToggleVisibilityCommand, Result>
    {
        public async Task<Result> Handle(ToggleVisibilityCommand request, CancellationToken cancellationToken)
        {
            var item = await unitOfWork.Items.GetByIdAsync(request.Id, cancellationToken);
            item.ToggleVisibility();

            var fieldsToUpdate = new BsonDocument("$set", new BsonDocument {
                {
                    nameof(item.IsVisible), item.IsVisible
                }
            });

            await unitOfWork.Items.SaveAsync(request.Id, fieldsToUpdate, cancellationToken);
            return Result.Ok();
        }
    }
}
