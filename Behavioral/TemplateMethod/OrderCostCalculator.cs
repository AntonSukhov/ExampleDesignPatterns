
namespace ExampleDesignPatterns.Behavioral.TemplateMethod;

public class OrderCostCalculator : BaseOrderCostCalculator
{
    public OrderCostCalculator(ILogger logger) : base(logger)
    {
    }

    protected override decimal CalculateProductCosts(IEnumerable<Product> products)
    {
        var totalSum = products.Sum(p => p.Cost * p.Count);
        return totalSum;
    }

    protected override decimal PercentageDiscountCalculation(string shopperEmail, IEnumerable<Product> products)
    {
        var discount = Random.Shared.Next(1, 30);
        return discount;
    }
}
