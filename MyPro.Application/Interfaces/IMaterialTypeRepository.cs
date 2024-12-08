using MyPro.Domain.Entities;

namespace MyPro.Application.Interfaces;

public interface IMaterialTypeRepository
{
    void AddMaterialType(MaterialType materialType);
    void UpdateMaterialType(MaterialType materialType);
    void DeleteMaterialType(Guid id);
    MaterialType GetMaterialTypeById(Guid id);
    IEnumerable<MaterialType> GetMaterialTypes();
}