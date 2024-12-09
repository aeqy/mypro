using MyPro.Domain.Common;

namespace MyPro.Domain.Events;

public class EventDispatcher: IEventDispatcher
{
    public async Task DispatchAsync(IEnumerable<IDomainEvent> events)
    {
        throw new NotImplementedException();
    }
}