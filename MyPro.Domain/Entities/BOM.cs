using System.Text.Json.Serialization;

namespace MyPro.Domain.Entities;

public class BOM
{
    public Guid Id { get; set; }
    public string Name { get; set; } // BOM 名称
    public string Code { get; set; } // BOM 编码
    public string Specification { get; set; } // BOM 规格
    public string Description { get; set; } // BOM 描述
    
    [JsonIgnore] // 忽略序列化 BOMMaterials 属性
    public ICollection<BomMaterial> BomMaterials { get; set; } // 关联的的物料信息
    public BOM()
    {
        BomMaterials = new List<BomMaterial>();
    }
}