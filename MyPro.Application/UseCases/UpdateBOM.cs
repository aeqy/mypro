using MyPro.Application.DTOs;
using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;

namespace MyPro.Application.UseCases;

public class UpdateBOM
{
    private readonly IBOMRepository _bomRepository;

    public UpdateBOM(IBOMRepository bomRepository)
    {
        _bomRepository = bomRepository;
    }
    public async Task<BOM> ExecuteAsync(Guid id, BOMDto bomDto)
    {
        // 检查是否存在指定ID 的 bom
        var existingBOM = await _bomRepository.GetByIdAsync(id);
        if (existingBOM == null)
        {
            throw new Exception($"BOM with id: {id} not found");
        }
        
        // 更新 BOM 的属性
        existingBOM.Name = bomDto.Name;
        existingBOM.Code = bomDto.Code;
        existingBOM.Description = bomDto.Description;
        existingBOM.Specification = bomDto.Specification;
        
        // 更新 BOMMaterials
        existingBOM.BomMaterials.Clear();
        foreach (var materDto in bomDto.Materials)
        {
            existingBOM.BomMaterials.Add(new BomMaterial
            {
                BOMId = id,
                MaterialTypeId = materDto.MaterialTypeId,
                Quantity = materDto.Quantity
            });
        }
        
        // 保存更新后的BOM
        return await _bomRepository.UpdateAsync(existingBOM);
    }
}