using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
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
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; init; }

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

        public string BrandId { get; private set; }
        /// <summary>
        /// Список категорий
        /// </summary>
        public IReadOnlyCollection<string> Categories => _categories;

        public List<string> _categories = [];

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

        public bool IsVisible { get; private set; }

        public Item(
            string displayName, 
            decimal price,
            string brandId,
            List<string> categories,
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
        }

        

        public void UpdateDisplayName(string newDisplayName)
        {
            DisplayName = newDisplayName;
        }

        public void UpdatePrice(decimal newPrice)
        {
            _price = newPrice;
        }

        public void UpdateBrandId(string newBrandId)
        {
            BrandId = newBrandId;
        }

        public void UpdateCategories(List<string> newCategories)
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

        public void UpdateDiscountPolicy(DiscountPolicy discountPolicy)
        {
            DiscountPolicy = discountPolicy;
        }

        public void AddCharacteristic(string key, string value)
        {
            _characteristics.Add(key, value);
        }

        public void AddCategory(string category)
        {
            _categories.Add(category);
        }

    }
}
