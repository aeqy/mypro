using MyPro.Domain.Entities;
using MyPro.Domain.ValueObjects;

namespace MyPro.Domain.Services;

/// <summary>
/// 物料领域服务
/// </summary>
public class MaterialTypeDomainService
{
    /// <summary>
    /// 验证物料的有效性
    /// </summary>
    /// <param name="materialType">要验证的物料</param>
    /// <returns>如果物料有效则返回 true，否则返回 false</returns>
    public bool ValidateMaterialType(MaterialType materialType)
    {
        if (string.IsNullOrEmpty(materialType.Name))
        {
            return false;
        }

        if (materialType.Price.Amount <=0)
        {
            return false;
        }

        if (materialType.Stock.Quantity <= 0 )
        {
            return false;
        }

        return false;
    }
    
    /// <summary>
    /// 计算物料的折扣价格
    /// </summary>
    /// <param name="materialType">物料</param>
    /// <param name="discountRate">折扣率</param>
    /// <returns>折扣后的价格</returns>
    public Money CalculateDiscountPrice(MaterialType materialType, decimal discountRate)
    {
        if (discountRate < 0 || discountRate > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(discountRate),"折扣率必须在0到1之间");
        }
        
        var discountedAmount = materialType.Price.Amount * (1- discountRate);
        return new Money(discountedAmount, materialType.Price.Currency);
    }
}