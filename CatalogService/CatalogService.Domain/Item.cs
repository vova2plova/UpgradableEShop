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
        /// TODO Убрать public set
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string DisplayName { get; private set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price 
        {
            get => _price;
        }

        /// <summary>
        /// Цена со скидкой
        /// </summary>
        public decimal DiscountPrice
        {
            // Применение скидки

            get => DiscountPolicy?.Apply(_price) ?? _price;
        }

        public decimal _price;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DiscountPolicy? DiscountPolicy { get; private set; }

        /// <summary>
        /// Рейтинг
        /// </summary>
        public decimal Rating { get; private set; }
        /// <summary>
        /// Идентификатор бренда
        /// </summary>
        public int BrandId { get; private set; }
        /// <summary>
        /// Список категорий
        /// </summary>
        public IReadOnlyCollection<Category> Categories => _categories;

        public List<Category> _categories = [];

        /// <summary>
        /// Картинка для карточки товара
        /// </summary>
        public string Thumbnail { get; private set; }

        /// <summary>
        /// Список изображений
        /// </summary>
        public IReadOnlyCollection<string>? Images => _images;
        private List<string> _images = [];

        /// <summary>
        /// Характеристики товара
        /// </summary>
        public IReadOnlyDictionary<string, string>? Characteristics => _characteristics;

        private Dictionary<string, string> _characteristics = [];

        public FeedbackSystem FeedbackSystem { get; } = new FeedbackSystem();

        public bool IsFavorite { get; private set; }
        public bool IsVisible { get; private set; }

        public Item(
            string displayName, 
            decimal price,
            int brandId,
            List<Category> categories,
            string thumbnail,
            bool isVisible,
            List<string>? images,
            Dictionary<string,string>? characteristics)
        {
            DisplayName = displayName;
            _price = price;
            BrandId = brandId;
            _categories = categories;
            Thumbnail = thumbnail;
            _images = images;
            _characteristics = characteristics;
            IsVisible = isVisible;
            IsFavorite = false;
        }

        

        public void UpdateDisplayName(string newDisplayName)
        {
            DisplayName = newDisplayName;
        }

        public void UpdatePrice(decimal newPrice)
        {
            _price = newPrice;
        }

        public void UpdateBrandId(int newBrandId)
        {
            BrandId = newBrandId;
        }

        public void UpdateCategories(List<Category> newCategories)
        {
            _categories = newCategories;
        }

        public void UpdateThumbnail(string newThumbnail)
        {
            Thumbnail = newThumbnail;
        }

        public void UpdateImages(List<string> newImages)
        {
            _images = newImages;
        }

        public void ToggleVisibility()
        {
            IsVisible = !IsVisible;
        }

        public void UpdateCharacteristics(Dictionary<string,string> newCharacteristics)
        {
            _characteristics = newCharacteristics;
        }
        
        public void ToggleIsFavorite()
        {
            IsFavorite = !IsFavorite;
        }

        public void UpdateDiscountPolicy(DiscountPolicy discountPolicy)
        {
            DiscountPolicy = discountPolicy;
        }

        public void AddCharacteristic(string key, string value)
        {
            _characteristics.Add(key, value);
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
