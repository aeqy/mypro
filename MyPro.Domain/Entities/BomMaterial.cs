namespace MyPro.Domain.Entities;

public class BomMaterial
{
    public Guid BOMId { get; set; } // 外键，指向 BOM
    public BOM BOM { get; set; } // 导航属性，指向 BOM 实体

    public Guid MaterialTypeId { get; set; } // 外键，指向 Material
    public MaterialType MaterialType { get; set; } // 导航属性，指向 Material 实体

    public int Quantity { get; set; } // 用量数量
}