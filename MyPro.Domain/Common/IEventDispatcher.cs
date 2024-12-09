namespace MyPro.Domain.Common;

/// <summary>
/// 定义事件调度器的接口
/// </summary>
public interface IEventDispatcher
{
    /// <summary>
    /// 异步分发领域事件
    /// </summary>
    /// <param name="events">要分发的领域事件集合</param>
    Task DispatchAsync(IEnumerable<IDomainEvent> events);
}