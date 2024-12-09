using MyPro.Domain.Entities;

namespace MyPro.Domain.Interfaces;

/// <summary>
/// 定义用于访问物料数据的接口
/// </summary>
public interface IMaterialTypeRepository
{
    /// <summary>
    /// 根据物料 ID 异步获取物料类型
    /// </summary>
    /// <param name="id">物料的唯一标识符</param>
    /// <returns>物料类型的任务对象</returns>
    Task<MaterialType> GetMaterialTypeByIdAsync(Guid id);

    /// <summary>
    /// 异步获取所有物料类型
    /// </summary>
    /// <returns>物料类型集合的任务对象</returns>
    Task<IEnumerable<MaterialType>> GetAllMaterialTypesAsync();

    /// <summary>
    /// 异步添加新的物料类型
    /// </summary>
    /// <param name="materialType">要添加的物料类型对象</param>
    /// <returns>表示异步操作的任务对象</returns>
    Task AddMaterialTypeAsync(MaterialType materialType);

    /// <summary>
    /// 异步更新现有的物料类型
    /// </summary>
    /// <param name="materialType">要更新的物料类型对象</param>
    /// <returns>表示异步操作的任务对象</returns>
    Task UpdateMaterialTypeAsync(MaterialType materialType);

    /// <summary>
    /// 根据物料 ID 异步删除物料类型
    /// </summary>
    /// <param name="id">要删除的物料类型的唯一标识符</param>
    /// <returns>表示异步操作的任务对象</returns>
    Task DeleteMaterialTypeAsync(Guid id);
}