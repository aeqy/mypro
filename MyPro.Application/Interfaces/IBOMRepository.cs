using MyPro.Domain.Entities;

namespace MyPro.Application.Interfaces;

/// <summary>
/// IBOMRepository 接口定义了与 BOM 实体相关的持久化操作
/// </summary>
public interface IBOMRepository
{
    // 创建新的 BOM 实体
    Task<BOM> CreateAsync(BOM bom);

    // 根据 ID 获取 BOM 实体
    Task<BOM> GetByIdAsync(Guid id);

    // 获取所有 BOM 实体
    Task<IEnumerable<BOM>> GetAllAsync();

    // 更新现有的 BOM 实体
    Task<BOM> UpdateAsync(BOM bom);

    // 根据 ID 删除 BOM 实体
    Task DeleteAsync(Guid id);
}