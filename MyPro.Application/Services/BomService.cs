using MyPro.Domain.Entities;
using MyPro.Domain.Interfaces;

namespace MyPro.Application.Services;

/// <summary>
/// 提供与 BOM（物料清单）相关的业务逻辑服务
/// </summary>
public class BomService
{
    private readonly IMaterialRepository _materialRepository;

    /// <summary>
    /// 初始化 BomService 类的新实例
    /// </summary>
    /// <param name="materialRepository">用于访问物料数据的仓储接口</param>
    public BomService(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository ?? throw new ArgumentNullException(nameof(materialRepository));
    }

    /// <summary>
    /// 获取使用指定物料的所有 BOM 的名称
    /// </summary>
    /// <param name="materialId">物料的唯一标识符</param>
    /// <returns>包含使用该物料的 BOM 名称的列表</returns>
    public async Task<List<string>> GetBoMsUsingMaterial(Guid materialId)
    {
        // 从仓储中获取所有包含指定物料的 BOM 组件
        var bomComponents = await _materialRepository.GetBoMsByMaterialIdAsync(materialId);

        // 提取每个 BOM 组件的父物料名称，并去重
        return bomComponents.Select(bc => bc.ParentMaterial.Name).Distinct().ToList();
    }

    /// <summary>
    /// 计算指定物料在所有 BOM 中的总用量
    /// </summary>
    /// <param name="materialId">物料的唯一标识符</param>
    /// <returns>包含物料名称和总用量的字典</returns>
    public async Task<Dictionary<string, int>> CalculateTotalQuantities(Guid materialId)
    {
        // 异步获取指定 ID 的物料
        var material = await _materialRepository.GetByIdAsync(materialId);
        if (material == null)
        {
            // 如果物料不存在，抛出异常
            throw new ArgumentException("Material not found.", nameof(materialId));
        }

        // 初始化一部字典用于存储物料名称和总用量
        var quantities = new Dictionary<string, int>();

        // 调用递归方法计算总用量
        CalculateQuantitiesRecursive(material, 1, quantities);

        // 返回计算结果
        return quantities;
    }

    /// <summary>
    /// 递归计算物料及其子组件的总用量
    /// </summary>
    /// <param name="material">当前物料对象</param>
    /// <param name="parentQuantity">父物料的数量</param>
    /// <param name="quantities">存储物料名称和总用量的字典</param>
    private void CalculateQuantitiesRecursive(MaterialType material, int parentQuantity,
        Dictionary<string, int> quantities)
    {
        // 遍历当前物料的所有 BOM 组件
        foreach (var component in material.BomComponents)
        {
            // 计算当前子物料的总用量
            var totalQuantity = component.Quantity * parentQuantity;
        
            // 尝试添加子物料到字典中，如果已存在则累加其用量
            if (!quantities.TryAdd(component.ChildMaterial.Name, totalQuantity))
            {
                quantities[component.ChildMaterial.Name] += totalQuantity;
            }
        
            // 递归计算子物料的子组件用量
            CalculateQuantitiesRecursive(component.ChildMaterial, totalQuantity, quantities);
        }
    }

    /// <summary>
    /// 获取所有物料及其组件关系
    /// </summary>
    /// <param name="id"></param>
    /// <returns>包含所有物料的列表</returns>
    public async Task<IEnumerable<MaterialType>> GetAllBoMsAsync(Guid id)
    {
        return await _materialRepository.GetAllBoMsAsync();
    }

    public async Task AddBomComponentAsync(Guid parentMaterialId, Guid childMaterialId, int quantity)
    {
        var parentMaterial = await _materialRepository.GetByIdAsync(parentMaterialId);
        var childMaterial = await _materialRepository.GetByIdAsync(childMaterialId);

        if (parentMaterial == null || childMaterial == null)
        {
            throw new ArgumentException("Parent material not found.", nameof(parentMaterialId));
        }

        var bC = new BomComponent
        {
            ParentMaterialId = parentMaterialId,
            ChildMaterialId = childMaterialId,
            Quantity = quantity,
            ParentMaterial = parentMaterial,
            ChildMaterial = childMaterial
        };
        
        parentMaterial.BomComponents.Add(bC);
        await _materialRepository.UpdateAsync(parentMaterial);
    }

    public async Task UpdateBomComponentAsync(Guid parentMaterialId, int quantity)
    {
        var bomComponent = await _materialRepository.GetByIdAsync(parentMaterialId);
    }

    public async Task AddBomComponentAsync(MaterialType parentMaterialId)
    {
        throw new NotImplementedException();
    }

    public async Task<object?> GetAllBoMsAsync()
    {
        throw new NotImplementedException();
    }
}