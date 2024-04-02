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
        public int Id { get; init; }
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
