namespace CatalogService.Domain
{
    /// <summary>
    /// Отзыв
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; init; }
        /// <summary>
        /// Оценка товару
        /// </summary>
        public int Rating { get; init; }
        /// <summary>
        /// Достоинства
        /// </summary>
        public string Advantages { get; init; }
        /// <summary>
        /// Недостатки
        /// </summary>
        public string Disadvantages{ get; init; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; init; }
        /// <summary>
        /// Прикреплённые изображения
        /// </summary>
        public IReadOnlyCollection<string> Images { get; init; }
    }
}
