using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Название
        /// </summary>
        public string DisplayName { get; init; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price 
        {
            // Применение скидки
            get => DiscountPolicy.Apply(_price);
        }

        public decimal _price;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DiscountPolicy DiscountPolicy { get; private set; }

        /// <summary>
        /// Рейтинг
        /// </summary>
        public decimal Rating => _rating;

        public decimal _rating;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Brand Brand { get; init; }

        /// <summary>
        /// Список категорий
        /// </summary>
        public IReadOnlyCollection<Category> Categories => _categories;

        public List<Category> _categories = new List<Category>();

        /// <summary>
        /// Картинка для карточки товара
        /// </summary>
        public string Thumbnail { get; init; }

        /// <summary>
        /// Список изображений
        /// </summary>
        public IReadOnlyCollection<string>? Images { get; init; } = new List<string>();

        /// <summary>
        /// Характеристики товара
        /// </summary>
        public IReadOnlyDictionary<string, string> Characteristic => _characteristic;

        private Dictionary<string, string> _characteristic = new Dictionary<string, string>();

        public FeedbackSystem FeedbackSystem { get; } = new FeedbackSystem();

        public bool IsFavorite { get; init; }
        public bool IsVisible { get; init; }

        public void AddCharacteristic(string key, string value)
        {
            _characteristic.Add(key, value);
        }

        public void UpdateDiscountPolicy(DiscountPolicy discountPolicy)
        {
            DiscountPolicy = discountPolicy;
        }

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }
    }

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
