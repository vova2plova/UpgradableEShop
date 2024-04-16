namespace CatalogService.Domain
{
    /// <summary>
    /// Рейтинговая система
    /// </summary>
    public class FeedbackSystem
    {
        /// <summary>
        /// Рейтинг товара
        /// </summary>
        public decimal Rating => _rating / CountFeedbacks;

        private int _rating;

        /// <summary>
        /// Кол-во отзывов
        /// </summary>
        public int CountFeedbacks => _countFeedbacks;

        private int _countFeedbacks;

        /// <summary>
        /// Список отзывов
        /// </summary>
        public IReadOnlyCollection<Feedback> Feedbacks => _feedbacks;

        private List<Feedback> _feedbacks = new List<Feedback>();

        /// <summary>
        /// Добавление отзыва
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="rating">Рейтинг товара</param>
        /// <param name="advantages">Достоинства</param>
        /// <param name="disadvantages">Недостатки</param>
        /// <param name="comment">Комментарий</param>
        /// <param name="images">Список изображений</param>
        public void AddFeedback(int userId, int rating, string advantages, string disadvantages, string comment, IReadOnlyCollection<string> images)
        {
            _feedbacks.Add(new Feedback
            {
                UserId = userId,
                Rating = rating,
                Advantages = advantages,
                Disadvantages = disadvantages,
                Comment = comment,
                Images = images
            });

            _rating += rating;
            _countFeedbacks++;
        }

    }
}
