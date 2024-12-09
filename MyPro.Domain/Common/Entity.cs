namespace MyPro.Domain.Common;

/// <summary>
/// 表示领域模型中的实体基类
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// 获取实体的唯一标识符
    /// </summary>
    protected Guid Id { get; private set; }
    

    private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// 添加领域事件
    /// </summary>
    /// <param name="domainEvent"></param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// 清除领域事件
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    
    /// <summary>
    /// 重写相等性比较
    /// </summary>
    public override bool Equals(object? obj)
    {
        var other = obj as Entity;
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Id.Equals(other.Id);
    }

    /// <summary>
    /// 重写获取哈希码
    /// </summary>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// 重载相等运算符
    /// </summary>
    public static bool operator ==(Entity a, Entity? b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// 重载不等运算符
    /// </summary>
    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }

    /// <summary>
    /// 克隆实体
    /// </summary>
    public Entity Clone()
    {
        return (Entity)this.MemberwiseClone();
    }
}