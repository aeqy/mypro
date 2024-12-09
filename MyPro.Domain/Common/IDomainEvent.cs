namespace MyPro.Domain.Common;

/// <summary>
/// 表示领域事件的接口
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// 获取事件发生的时间
    /// </summary>
    DateTime OccurredOn { get; }
}