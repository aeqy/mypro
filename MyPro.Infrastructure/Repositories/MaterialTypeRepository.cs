using Microsoft.EntityFrameworkCore;
using MyPro.Domain.Entities;
using MyPro.Domain.Interfaces;
using MyPro.Infrastructure.DbContex;

namespace MyPro.Infrastructure.Repositories;

/// <summary>
/// 物料类型仓储实现
/// </summary>
public class MaterialTypeRepository(MyProDbContext context) : IMaterialTypeRepository
{
    /// <summary>
    /// 根据物料 ID 异步获取物料类型
    /// </summary>
    /// <param name="id">物料的唯一标识符</param>
    /// <returns>物料类型的任务对象</returns>
    public async Task<MaterialType> GetMaterialTypeByIdAsync(Guid id)
    {
        // 调用仓储方法获取物料类型
        var materialType = await context.MaterialTypes.FindAsync(id);

        // 检查返回的物料类型是否为 null
        if (materialType == null)
        {
            throw new KeyNotFoundException($"MaterialType with ID {id} not found.");
        }

        return materialType;
    }

    /// <summary>
    /// 异步获取所有物料类型
    /// </summary>
    /// <returns>物料类型集合的任务对象</returns>
    public async Task<IEnumerable<MaterialType>> GetAllMaterialTypesAsync()
    {
        // 使用 ToListAsync 方法获取所有物料类型
        return await context.MaterialTypes.ToListAsync();
    }

    /// <summary>
    /// 异步添加新的物料类型
    /// </summary>
    /// <param name="materialType">要添加的物料类型对象</param>
    /// <returns>表示异步操作的任务对象</returns>
    public async Task AddMaterialTypeAsync(MaterialType materialType)
    {
        // 使用 AddAsync 方法添加新的物料类型
        await context.MaterialTypes.AddAsync(materialType);
        // 保存更改到数据库
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// 异步更新现有的物料类型
    /// </summary>
    /// <param name="materialType">要更新的物料类型对象</param>
    /// <returns>表示异步操作的任务对象</returns>
    public async Task UpdateMaterialTypeAsync(MaterialType materialType)
    {
        // 使用 Update 方法更新物料类型
        context.MaterialTypes.Update(materialType);
        // 保存更改到数据库
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// 根据物料 ID 异步删除物料类型
    /// </summary>
    /// <param name="id">要删除的物料类型的唯一标识符</param>
    /// <returns>表示异步操作的任务对象</returns>
    public async Task DeleteMaterialTypeAsync(Guid id)
    {
        // 根据 ID 获取物料类型
        var materialType = await GetMaterialTypeByIdAsync(id);
        // 使用 Remove 方法删除物料类型
        context.MaterialTypes.Remove(materialType);
        // 保存更改到数据库
        await context.SaveChangesAsync();
    }
}