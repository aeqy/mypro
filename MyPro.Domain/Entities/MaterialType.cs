using MyPro.Domain.Common;
using MyPro.Domain.Events;
using MyPro.Domain.ValueObjects;

namespace MyPro.Domain.Entities;

/// <summary>
/// 表示物料类型的聚合根
/// </summary>
public class MaterialType : Entity, IAggregateRoot
{
    public Guid Id { get; protected set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public Stock Stock { get; private set; }

    public MaterialType(Guid id, string name, string description, Money price, Stock stock)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }

    public void UpdateDetails(string name, string description, Money price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public void AdjustStock(int quantity)
    {
        // 使用 Stock 值对象的 Adjust 方法来返回一个新的 Stock 实例
        Stock = Stock.Adjust(quantity);
        AddDomainEvent(new StockAdjustedEvent(this, quantity));
    }
    
    private MaterialType() {}
}