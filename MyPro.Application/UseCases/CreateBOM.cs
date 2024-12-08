using MyPro.Application.DTOs;
using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;

namespace MyPro.Application.UseCases;

/// <summary>
/// CreateBOM 用例类，负责处理创建 BOM 的业务逻辑
/// </summary>
public class CreateBOM
{
    private readonly IBOMRepository _bomRepository;

    /// <summary>
    /// 通过依赖注入获取BOM 仓库接口
    /// </summary>
    /// <param name="bomRepository"></param>
    public CreateBOM(IBOMRepository bomRepository)
    {
        _bomRepository = bomRepository;
    }

    public async Task<BOM> Handle(BOMDto bomDto)
    {
        // 将DTO 转换实体
        var bom = new BOM
        {
            Id = Guid.NewGuid(),
            Name = bomDto.Name,
            Code = bomDto.Code,
            Specification = bomDto.Specification,
            Description = bomDto.Description,
            BomMaterials = bomDto.Materials.Select(m => new BomMaterial
            {
                BOMId = Guid.NewGuid(),
                MaterialTypeId = m.MaterialTypeId,
                Quantity = m.Quantity,
            }).ToList()
        };
        
        // 调用仓库方法创建 BOM
        return await _bomRepository.CreateAsync(bom);
    }
}