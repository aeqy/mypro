using Microsoft.EntityFrameworkCore;
using MyPro.Domain.Entities;
using MyPro.Domain.Repositories;
using MyPro.Infrastructure.DbContex;

namespace MyPro.Infrastructure.Repositories;

public class MaterialTypeRepository: IMaterialTypeRepository
{
    private readonly MyProDbContext _context;

    public MaterialTypeRepository(MyProDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<MaterialType>> GetAllAsync()
    {
        return await _context.MaterialTypes.ToListAsync();
    }

    public async Task<MaterialType> GetByIdAsync(Guid id)
    {
        return await _context.MaterialTypes.FindAsync(id);
    }

    public async Task AddAsync(MaterialType material)
    {
        await _context.MaterialTypes.AddAsync(material);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MaterialType material)
    {
        _context.MaterialTypes.Update(material);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var m = await GetByIdAsync(id);
        if (m != null)
        {
            _context.MaterialTypes.Remove(m);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<MaterialType>> SearchAsync(string keyword)
    {
        return await _context.MaterialTypes.Where(m => m.Name.Contains(keyword) || m.Description.Contains(keyword) ).ToListAsync();
    }
}