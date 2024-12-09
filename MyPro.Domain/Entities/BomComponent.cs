namespace MyPro.Domain.Entities;

/// <summary>
/// 表示 BOM 中的组件关系
/// </summary>
public class BomComponent
{
    /// <summary>
    /// 获取或设置父物料的唯一标识符
    /// </summary>
    public Guid ParentMaterialId { get; set; }

    /// <summary>
    /// 获取或设置父物料的实体对象
    /// </summary>
    public MaterialType ParentMaterial { get; set; }

    /// <summary>
    /// 获取或设置子物料的唯一标识符
    /// </summary>
    public Guid ChildMaterialId { get; set; }

    /// <summary>
    /// 获取或设置子物料的实体对象
    /// </summary>
    public MaterialType ChildMaterial { get; set; }

    /// <summary>
    /// 获取或设置子物料在父物料中的用量
    /// </summary>
    public int Quantity { get; set; }
}