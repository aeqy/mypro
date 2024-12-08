using Microsoft.EntityFrameworkCore;
using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;
using MyPro.Infrastructure.DbContex;

namespace MyPro.Infrastructure.Repositories;

/// <summary>
/// BOMRepository 类实现了 IBOMRepository 接口
/// </summary>
public class BOMRepository: IBOMRepository
{
    private readonly MyProDbContext _context;

    /// <summary>
    /// 通过依赖注入获取数据库上下文
    /// </summary>
    /// <param name="context"></param>
    public BOMRepository(MyProDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// 创建新的bom 实体并保存到数据库
    /// </summary>
    /// <param name="bom"></param>
    /// <returns></returns>
    public async Task<BOM> CreateAsync(BOM bom)
    {
        // 将新的 BOM 实体添加到上下文
        await _context.Set<BOM>().AddAsync(bom);
        // 保存更改到数据库
        await _context.SaveChangesAsync();
        // 返回创建的 Bom 实体
        return bom;
    }

    /// <summary>
    /// 根据ID 获取BOM实体
    /// </summary>
    /// <param name="id">根据ID 获取</param>
    /// <returns></returns>
    public async Task<BOM> GetByIdAsync(Guid id)
    {
        // // 从数据库中查找具有指定 ID 的BOM 实体
        // var bom = await _context.BOMs
        //     .Include(b => b.MaterialTypes) // 包括相关物料信息
        //     .FirstOrDefaultAsync( b => b.Id == id);
        //
        // // 如果找不到 BOM，抛出异常或返回 null
        // if (bom == null)
        // {
        //     throw new KeyNotFoundException($"BOM with ID {id} not found.,查无此人");
        // }
        //
        // return bom;

        var bom = await _context.Set<BOM>()
            .Include(b => b.BomMaterials)
            .ThenInclude(bm => bm.MaterialType)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (bom == null)
        {
            throw new KeyNotFoundException($"BOM with ID {id} not found.,查无此人");
        }
        return bom;
    }

    /// <summary>
    /// 获取所有Bom 实体
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<BOM>> GetAllAsync()
    {
        return await _context.Set<BOM>()
            .Include(b => b.BomMaterials)
            .ThenInclude(bm => bm.MaterialType)
            .ToListAsync();
    }

    /// <summary>
    /// 更新现有BOM实体
    /// </summary>
    /// <param name="bom"></param>
    /// <returns></returns>
    public async Task<BOM> UpdateAsync(BOM bom)
    {
        // 更新上下文中 Bom 实体
       _context.Set<BOM>().Update(bom);
       // 保存更改到数据库
       await _context.SaveChangesAsync();
       // 返回更新后的BOM实体
       return bom;
    }

    /// <summary>
    /// 删除BOM 实体
    /// </summary>
    /// <param name="id">根据Id 删除</param>
    public async Task DeleteAsync(Guid id)
    {
        // 查找要删除的 Bom 实体
        var bom = await _context.Set<BOM>().FindAsync(id);
        if (bom != null)
        {
            // 从上下文中删除 Bom 实体
            _context.Set<BOM>().Remove(bom);
            // 保存更改到数据库
            await _context.SaveChangesAsync();
        }
    }
}