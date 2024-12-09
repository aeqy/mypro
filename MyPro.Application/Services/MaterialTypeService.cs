using MyPro.Domain.Common;
using MyPro.Domain.Entities;
using MyPro.Domain.Interfaces;
using MyPro.Domain.Repositories;
using MyPro.Domain.Services;

namespace MyPro.Application.Services;

public class MaterialTypeService:IMaterialTypeService
{
    private readonly IMaterialTypeRepository _materialTypeRepository;
    private readonly MaterialTypeDomainService _materialTypeDomainService;
    private readonly IEventDispatcher _eventDispatcher;

    public MaterialTypeService(IMaterialTypeRepository materialTypeRepository, IEventDispatcher eventDispatcher, MaterialTypeDomainService materialTypeDomainService)
    {
        _materialTypeRepository = materialTypeRepository;
        _eventDispatcher = eventDispatcher;
        _materialTypeDomainService = materialTypeDomainService;
    }
    
    public async Task<IEnumerable<MaterialType>> GetAllMaterialTypesAsync()
    {
        // 从仓储中获取所有物料
        return await _materialTypeRepository.GetAllAsync();
    }

    public async Task<MaterialType> GetMaterialTypeByIdAsync(Guid id)
    {
       return await _materialTypeRepository.GetByIdAsync(id);
    }

    public async Task AddMaterialTypeAsync(MaterialType material)
    {
        // 验证物料类型
        if (material == null || string.IsNullOrWhiteSpace(material.Name))
        {
            throw new ArgumentException("Invalid material type: Name is required.");
        }

        // 其他验证逻辑
        // if (!IsValid(materialType)) { throw new ArgumentException("Invalid material type: [具体原因]"); }

        await _materialTypeRepository.AddAsync(material);
        _eventDispatcher.DispatchAsync(new List<IDomainEvent> { /* 事件实例 */ });
    }

    public async Task UpdateMaterialTypeAsync(MaterialType material)
    {
        if (material == null || string.IsNullOrWhiteSpace(material.Name))
        {
            throw new AggregateException("Invalid material type: Name is required.");
        }
        await _materialTypeRepository.UpdateAsync(material);
        _eventDispatcher.DispatchAsync(new List<IDomainEvent> {  });
    }

    public async Task DeleteMaterialTypeAsync(Guid id)
    {
        await _materialTypeRepository.DeleteAsync(id);
        _eventDispatcher.DispatchAsync(new List<IDomainEvent> {  });
    }

    public async Task<IEnumerable<MaterialType>> SearchAsync(string keyword)
    {
        return await _materialTypeRepository.SearchAsync(keyword);
    }
}