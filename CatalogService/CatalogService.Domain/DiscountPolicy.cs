namespace CatalogService.Domain
{
    /// <summary>
    /// Скидочная политика (Factory method)
    /// </summary>
    public abstract class DiscountPolicy
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// Создание скидочной политики
        /// </summary>
        /// <returns>Скидка</returns>
        public abstract DiscountBase Create();
        /// <summary>
        /// Применение скидки
        /// </summary>
        /// <param name="Price">Цена товара</param>
        /// <returns>Цена товара после скидки</returns>
        public decimal Apply(decimal Price)
        {
            var discount = Create();
            return Price * (1 - discount.GetPercentage());
        }

    }

    public abstract class DiscountBase
    {
        public abstract decimal GetPercentage();
    }

    public class RegularDiscount : DiscountBase
    {
        public override decimal GetPercentage() => 0.1m;
    }

    public class IrregularDiscount : DiscountBase
    {
        public override decimal GetPercentage() => 0.15m;
    }

    public class RegularDiscountPolicy : DiscountPolicy
    {
        public override DiscountBase Create() => new RegularDiscount();
    }

    public class IrregularDiscountPolicy : DiscountPolicy
    {
        public override DiscountBase Create() => new IrregularDiscount();
    }
}
