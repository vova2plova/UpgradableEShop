using CatalogService.Application.Validator;

namespace CatalogService.Application.Behaviours
{
    /// <summary>
    /// Пайплайн валидации входящих команд
    /// </summary>
    /// <param name="_validator"></param>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : Result, new() 
        where TRequest : IBaseRequest
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <inheritdoc/>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var typeName = request.GetGenericTypeName();

            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();


            if (failures.Count != 0)
            {
                var result = new TResponse();
                result.Reasons.AddRange(failures);
                return result;
            }

            return await next();
        }
    }
}
