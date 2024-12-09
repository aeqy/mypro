using MyPro.Domain.Entities;
using MyPro.Domain.ValueObjects;

namespace MyPro.Domain.Services;

public class MaterialTypePricingService
{
    public Money CalculateDiscountedPrice(MaterialType materialType, decimal discountRate)
    {
        if (materialType == null)
            throw new ArgumentNullException(nameof(materialType));

        if (discountRate < 0 || discountRate > 1)
            throw new ArgumentOutOfRangeException(nameof(discountRate), "折扣率必须在0到1之间");
        
        var discountedAmount = materialType.Price.Amount * (1 - discountRate);
        return new Money(discountedAmount, materialType.Price.Currency);
    }
}