namespace MyPro.Domain.Entities;

/// <summary>
/// 表示一个物品或组件的实体类
/// </summary>
public class MaterialType
{
    /// <summary>
    /// 获取或设置物品的唯一标识符
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// 获取或设置物品的代码，用于唯一标识物品
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// 获取或设置物品的名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 获取或设置物品的规格说明
    /// </summary>
    public required string Specification { get; init; }

    /// <summary>
    /// 获取或设置物品的描述信息
    /// </summary>
    public required string Description { get; init; }

    // 该物料或产品的 BOM 组件
    // 使用延迟初始化的导航属性
    private readonly ICollection<BomComponent> _bomComponents = new List<BomComponent>();
    public ICollection<BomComponent> BomComponents
    {
        get => _bomComponents;
        init => _bomComponents = value ?? throw new ArgumentNullException(nameof(value));
    }
}