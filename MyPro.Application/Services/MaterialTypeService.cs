using MyPro.Domain.Entities;
using MyPro.Domain.Interfaces;

namespace MyPro.Application.Services;

/// <summary>
/// 物料清单相关的业务逻辑服务
/// </summary>
public class MaterialTypeService(IMaterialTypeRepository repository)
{
    private readonly IMaterialTypeRepository _repository = repository;

    /// <summary>
    /// 根据物料 ID 异步获取物料类型
    /// </summary>
    /// <param name="id">物料的唯一标识符</param>
    /// <returns>物料类型的任务对象</returns>
    public async Task<MaterialType> GetMaterialTypeByIdAsync(Guid id)
    {
        var m = await _repository.GetMaterialTypeByIdAsync(id);

        if (m == null)
        {
            throw new KeyNotFoundException($"MaterialType with ID {id} not found.");
        }

        return m;
    }

    /// <summary>
    /// 异步获取所有物料类型
    /// </summary>
    /// <returns>物料类型集合的任务对象</returns>
    public async Task<IEnumerable<MaterialType>> GetAllMaterialTypesAsync()
    {
        return await _repository.GetAllMaterialTypesAsync();
    }

    /// <summary>
    /// 异步添加新的物料类型
    /// </summary>
    /// <param name="materialType">要添加的物料类型对象</param>
    /// <returns>表示异步操作的任务对象</returns>
    public async Task AddMaterialTypeAsync(MaterialType materialType)
    {
        if (materialType == null)
        {
            throw new ArgumentNullException(nameof(materialType));
        }

        await _repository.AddMaterialTypeAsync(materialType);
    }

    /// <summary>
    /// 异步更新现有的物料类型
    /// </summary>
    /// <param name="materialType">要更新的物料类型对象</param>
    /// <returns>表示异步操作的任务对象</returns>
    public async Task UpdateMaterialTypeAsync(MaterialType materialType)
    {
        if (materialType == null)
        {
            throw new ArgumentNullException(nameof(materialType));
        }

        await _repository.UpdateMaterialTypeAsync(materialType);
    }

    /// <summary>
    /// 根据物料 ID 异步删除物料类型
    /// </summary>
    /// <param name="id">要删除的物料类型的唯一标识符</param>
    /// <returns>表示异步操作的任务对象</returns>
    public async Task DeleteMaterialTypeAsync(Guid id)
    {
        var materialType = await _repository.GetMaterialTypeByIdAsync(id);
        if (materialType == null)
        {
            throw new KeyNotFoundException($"MaterialType with ID {id} not found.");
        }

        await _repository.DeleteMaterialTypeAsync(id);
    }
}