using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MyPro.Domain.Entities;
using MyPro.Domain.Interfaces;
using MyPro.Infrastructure.DbContex;

namespace MyPro.Infrastructure.Repositories;

/// <summary>
/// 实现 IMaterialRepository 接口，提供对物料数据的访问
/// </summary>
public class MaterialRepository(MyProDbContext context) : IMaterialRepository
{
    /// <summary>
    /// 获取所有物料及其 BOM 组件
    /// </summary>
    /// <returns>包含所有物料的列表</returns>
    public async Task<IEnumerable<MaterialType>> GetAllBoMsAsync()
    {
        // 使用 Include 方法加载相关的 BOM 组件
        return await context.MaterialTypes
            .Include(mt => mt.BomComponents) // 加载 BOM 组件
            .ThenInclude(bc => bc.ChildMaterial) // 加载子物料信息
            .ToListAsync(); // 异步转换为列表
    }

    /// <summary>
    /// 根据物料 ID 获取所有使用该物料的 BOM 组件
    /// </summary>
    /// <param name="materialId">物料的唯一标识符</param>
    /// <returns>包含该物料的 BOM 组件列表</returns>
    public async Task<List<BomComponent>> GetBoMsByMaterialIdAsync(Guid materialId)
    {
        // 查询 BOMComponent 表，获取所有包含指定 ChildMaterialId 的记录
        return await context.BomComponents
            .Include(bc => bc.ParentMaterial) // 包含 ParentMaterial 信息
            .Where(bc => bc.ChildMaterialId == materialId) // 筛选条件
            .ToListAsync(); // 异步转换为列表
    }

    /// <summary>
    /// 根据 ID 获取物料
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<MaterialType> GetByIdAsync(Guid id)
    {
        var m =  await context.MaterialTypes
            .Include(mt => mt.BomComponents)
            .ThenInclude(bc => bc.ChildMaterial)
            .FirstOrDefaultAsync(mt => mt.Id == id);
        
        if (m == null)
        {
            throw new KeyNotFoundException($"Material with ID {id} not found.");
        }
        return m;
    }

    public async Task AddAsync(MaterialType material)
    {
        await context.MaterialTypes.AddAsync(material);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MaterialType material)
    {
        context.MaterialTypes.Update(material);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var m = await GetByIdAsync(id);
        if (m != null)
        {
            context.MaterialTypes.Remove(m);
            context.SaveChanges();
        }
    }

    public Task GetBomComponentByIdAsync(Guid bomComponentId)
    {
        throw new NotImplementedException();
    }
}