using MyPro.Domain.Entities;

namespace MyPro.Domain.Repositories;

/// <summary>
/// 定义物料仓储的接口
/// </summary>
public interface IMaterialTypeRepository
{
    /// <summary>
    /// 获取所有物料
    /// </summary>
    Task<IEnumerable<MaterialType>> GetAllAsync();

    /// <summary>
    /// 根据ID获取物料
    /// </summary>
    Task<MaterialType> GetByIdAsync(Guid id);

    /// <summary>
    /// 添加新的物料
    /// </summary>
    Task AddAsync(MaterialType material);

    /// <summary>
    /// 更新物料信息
    /// </summary>
    Task UpdateAsync(MaterialType material);

    /// <summary>
    /// 删除物料
    /// </summary>
    Task DeleteAsync(Guid id);
    
    /// <summary>
    /// 模糊搜索方法
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    Task<IEnumerable<MaterialType>> SearchAsync(string keyword);
}