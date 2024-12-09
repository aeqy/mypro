namespace MyPro.Domain.ValueObjects;

/// <summary>
/// 表示库存的值对象
/// </summary>
public class Stock
{
    /// <summary>
    /// 获取库存数量
    /// </summary>
    public int Quantity { get; private set; }

    public Stock(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("库存数量不能为负数", nameof(quantity));
        Quantity = quantity;
    }

    /// <summary>
    /// 调整库存数量
    /// </summary>
    /// <param name="quantity">调整的数量</param>
    /// <returns>调整后的库存</returns>
    public Stock Adjust(int quantity)
    {
        return new Stock(Quantity + quantity);
    }
    
    private Stock(){}
}