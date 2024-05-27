namespace CatalogService.Application.Validator
{
    /// <summary>
    /// Интерфейс для объявления валидации для использования в <see cref="ValidationBehaviour"/>
    /// </summary>
    /// <typeparam name="T">Валидатор команды / запроса</typeparam>
    public interface IValidator<T> where T : IBaseRequest
    {
        /// <summary>
        /// Валидация команды / запроса
        /// </summary>
        /// <param name="request">Команда / запрос</param>
        /// <returns>Результат Валидации</returns>
        Result Validate(T request);
    }
}
