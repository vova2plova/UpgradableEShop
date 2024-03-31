using System;
using System.Collections.Generic;
using System.Linq;
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
        public decimal Price { get; init; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DiscountPolicy DiscountPolicy { get; init; }
        /// <summary>
        /// Рейтинг
        /// </summary>
        public decimal Rating { get; init; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Brand Brand { get; init; }
        /// <summary>
        /// Список категорий
        /// </summary>
        public List<Category> Categories { get; init; }
        /// <summary>
        /// Картинка для карточки товара
        /// </summary>
        public string Thumbnail { get; init; }
        /// <summary>
        /// Список изображений
        /// </summary>
        public List<string>? Images { get; init; }
        /// <summary>
        /// Характеристики товара
        /// </summary>
        public Dictionary<string, string> Characteristic { get; init; }
    }

    /// <summary>
    /// Категория
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// Название
        /// </summary>
        public string DisplayName { get; init; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Brand
    {
        public int Id { get; init; }
        public string DisplayName { get; init; }
        public string Logo { get; init; }
    }

    public class DiscountPolicy
    {
        public int Id { get; init; }
        public decimal Percentage { get; init; }
    }
}
