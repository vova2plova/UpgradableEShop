using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogService.Domain
{
    /// <summary>
    /// Бренд
    /// </summary>
    public class Brand
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; init; }
        /// <summary>
        /// Название бренда
        /// </summary>
        public string DisplayName { get; init; }
        /// <summary>
        /// Логотип
        /// </summary>
        public string Logo { get; init; }
    }
}
