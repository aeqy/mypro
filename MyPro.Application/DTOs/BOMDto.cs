using MyPro.Domain.Entities;

namespace MyPro.Application.DTOs;

public class BOMDto
{
    public string Name { get; set; } // BOM 名称
    public string Code { get; set; } // BOM 编码
    public string Specification { get; set; } // BOM 规格
    public string Description { get; set; } // BOM 描述
    public List<BomMaterialDto> Materials { get; set; }

    public BOMDto()
    {
        Materials = new List<BomMaterialDto>();
    }
}

public class BomMaterialDto
{
    public Guid MaterialTypeId { get; set; } // 物料ID
    public int Quantity { get; set; }    // 用量数量
} 