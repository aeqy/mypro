using MyPro.Domain.Common;
using MyPro.Domain.Entities;

namespace MyPro.Domain.Events;

/// <summary>
/// 表示库存调整的领域事件
/// </summary>
public class StockAdjustedEvent(MaterialType materialType, int quantity) : IDomainEvent
{
    public MaterialType MaterialType { get; } = materialType;
    public int Quantity { get; } = quantity;

    public DateTime OccurredOn { get; } = DateTime.UtcNow; // 设置事件发生时间
}