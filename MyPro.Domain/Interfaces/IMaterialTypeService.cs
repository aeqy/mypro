using MyPro.Domain.Entities;

namespace MyPro.Domain.Interfaces;

/// <summary>
/// 定义物料服务的接口
/// </summary>
public interface IMaterialTypeService
{
    /// <summary>
    /// 获取所有物料
    /// </summary>
    Task<IEnumerable<MaterialType>> GetAllMaterialTypesAsync();

    /// <summary>
    /// 根据ID获取物料
    /// </summary>
    Task<MaterialType> GetMaterialTypeByIdAsync(Guid id);

    /// <summary>
    /// 添加新的物料
    /// </summary>
    Task AddMaterialTypeAsync(MaterialType material);

    /// <summary>
    /// 更新物料信息
    /// </summary>
    Task UpdateMaterialTypeAsync(MaterialType material);

    /// <summary>
    /// 删除物料
    /// </summary>
    Task DeleteMaterialTypeAsync(Guid id);
    
    Task<IEnumerable<MaterialType>> SearchAsync(string keyword);
}