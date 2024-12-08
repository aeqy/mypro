using Microsoft.EntityFrameworkCore;
using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;
using MyPro.Infrastructure.DbContex;

namespace MyPro.Infrastructure.Repositories;

public class MaterialTypeRepository: IMaterialTypeRepository
{
    private readonly MyProDbContext _context;

    public MaterialTypeRepository(MyProDbContext context)
    {
        _context = context;
    }
    public void AddMaterialType(MaterialType materialType)
    {
        _context.MaterialTypes.Add(materialType);
        _context.SaveChanges();
    }

    public void UpdateMaterialType(MaterialType materialType)
    {
        var existingMaterialType = _context.MaterialTypes.Find(materialType.Id);
        if (existingMaterialType != null)
        {
            existingMaterialType.Code = materialType.Code;
            existingMaterialType.Name = materialType.Name;
            existingMaterialType.Specification = materialType.Specification;
            existingMaterialType.Description = materialType.Description;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception(" 并发冲突，请重试一下");
            }
        }
    }

    public void DeleteMaterialType(Guid id)
    {
        var material = _context.MaterialTypes.Find(id);
        if (material != null)
        {
            _context.MaterialTypes.Remove(material);
            _context.SaveChanges();
        }
    }

    public MaterialType GetMaterialTypeById(Guid id)
    {
        return _context.MaterialTypes.Find(id);
    }

    public IEnumerable<MaterialType> GetMaterialTypes()
    {
        return _context.MaterialTypes.ToList();
    }
}