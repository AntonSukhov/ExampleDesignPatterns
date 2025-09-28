using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.TemplateMethod;

/// <summary>
/// Калькулятор стоимости заказа.
/// </summary>
public abstract class BaseOrderCostCalculator
{
    protected readonly ILogger _logger;

    protected BaseOrderCostCalculator(ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }


    /// <summary>
    /// Рассчитывает стоимость заказа.
    /// </summary>
    /// <param name="shopperEmail">Электронная почта покупателя</param>
    /// <param name="products">Товары, входящие в заказ.</param>
    /// <returns>Стоимость заказа.</returns>
    public decimal Сalculate(string shopperEmail, IEnumerable<Product> products)
    {
        try
        {
            ValidationInputData(shopperEmail, products);

            var productCosts = CalculateProductCosts(products);
            var discount = PercentageDiscountCalculation(shopperEmail, products);
            
            var discountCosts = productCosts / 100 * discount;
            var total = productCosts - discountCosts;

            return total;
        }
        catch (Exception exception)
        {
            _logger.Log(exception);

            throw;
        }
    }

    private static void ValidationInputData(string shopperEmail, IEnumerable<Product> products)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(shopperEmail);
        ArgumentNullException.ThrowIfNull(products);

        if (!products.Any())
            throw new CustomException($"В заказ не добавлен товар.");
    }


    /// <summary>
    /// Рассчитывает стоимость товаров в заказе.
    /// </summary>
    /// <param name="products">Товары, входящие в заказ.</param>
    /// <returns>стоимость товаров в заказе.</returns>
    protected abstract decimal CalculateProductCosts(IEnumerable<Product> products);

    /// <summary>
    /// Рассчитывает скидку покупателя в %. 
    /// </summary>
    /// <param name="shopperEmail">Электронная почта покупателя</param>
    /// <param name="products">Товары, входящие в заказ.</param>
    /// <returns>Размер скидки в %.</returns>
    protected abstract decimal PercentageDiscountCalculation(string shopperEmail, IEnumerable<Product> products);
}
