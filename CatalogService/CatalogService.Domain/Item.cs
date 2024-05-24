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
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; init; }

        public string DisplayName { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price 
        {
            get => _price;
            set => _price = value;
        }

        /// <summary>
        /// Цена со скидкой
        /// </summary>
        public decimal DiscountPrice
        {
            // Применение скидки

            get => DiscountPolicy?.Apply(_price) ?? _price;
        }

        private decimal _price;

        public DiscountPolicy? DiscountPolicy { get; private set; }

        public decimal Rating { get; private set; }

        public string BrandId { get; private set; }
        public IReadOnlyCollection<string> Categories { get; set; }

        public string Thumbnail { get; private set; }

        public IReadOnlyCollection<string>? Images { get; set; }

        public IReadOnlyDictionary<string, string>? Characteristics { get; set; }

        public FeedbackSystem FeedbackSystem { get; } = new FeedbackSystem();

        public bool IsVisible { get; private set; }

        public Item(
            string displayName, 
            string description,
            decimal price,
            string brandId,
            List<string> categories,
            string thumbnail,
            bool isVisible,
            List<string>? images,
            Dictionary<string,string>? characteristics)
        {
            DisplayName = displayName;
            Description = description;
            Price = price;
            BrandId = brandId;
            Categories = categories;
            Thumbnail = thumbnail;
            Images = images;
            Characteristics = characteristics;
            IsVisible = isVisible;
        }


        public void ToggleVisibility()
        {
            IsVisible = !IsVisible;
        }
    }
}
