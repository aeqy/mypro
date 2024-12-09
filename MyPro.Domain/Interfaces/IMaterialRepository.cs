using MyPro.Domain.Entities;

namespace MyPro.Domain.Interfaces;

/// <summary>
/// 定义用于访问物料数据的接口
/// </summary>
public interface IMaterialRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<MaterialType>> GetAllBoMsAsync();
    /// <summary>
    /// 根据物料 ID 获取所有使用该物料的 BOM 组件
    /// </summary>
    /// <param name="materialId">物料的唯一标识符</param>
    /// <returns>包含该物料的 BOM 组件列表</returns>
    Task<List<BomComponent>> GetBoMsByMaterialIdAsync(Guid materialId);

    // 其他可能的方法
    
    /// <summary>
    /// 根据物料 ID 获取物料实体
    /// </summary>
    /// <param name="id">物料的唯一标识符</param>
    /// <returns>物料实体对象</returns>
    Task<MaterialType> GetByIdAsync(Guid id);
    Task AddAsync(MaterialType material);
    Task UpdateAsync(MaterialType material);
    Task DeleteAsync(Guid id);

    /// <summary>
    /// 用于根据BOM组件的唯一标识符从数据库中检索特定的BOM组件
    /// </summary>
    /// <param name="bomComponentId"></param>
    /// <returns></returns>
    Task GetBomComponentByIdAsync(Guid bomComponentId); 
}