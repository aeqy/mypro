using Microsoft.AspNetCore.Mvc;
using MyPro.Application.Services;
using MyPro.Domain.Entities;

namespace MyPro.WebAPI.Controllers;

/// <summary>
/// 物品或组件 API  控制器
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MaterialTypeController(MaterialTypeService materialTypeService) : ControllerBase
{
    private readonly MaterialTypeService _materialTypeService = materialTypeService;
    

    /// <summary>
    /// 根据物料 ID 获取物料类型
    /// </summary>
    /// <param name="id">物料的唯一标识符</param>
    /// <returns>物料类型对象</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMaterialType(Guid id)
    {
        try
        {
            var materialType = await _materialTypeService.GetMaterialTypeByIdAsync(id);
            return Ok(materialType);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// 获取所有物料类型
    /// </summary>
    /// <returns>物料类型集合</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllMaterialTypes()
    {
        var materialTypes = await _materialTypeService.GetAllMaterialTypesAsync();
        return Ok(materialTypes);
    }

    /// <summary>
    /// 创建新的物料类型
    /// </summary>
    /// <param name="materialType">要创建的物料类型对象</param>
    /// <returns>创建的物料类型对象</returns>
    [HttpPost]
    public async Task<IActionResult> CreateMaterialType([FromBody] MaterialType materialType)
    {
        await _materialTypeService.AddMaterialTypeAsync(materialType);
        return CreatedAtAction(nameof(GetMaterialType), new { id = materialType.Id }, materialType);
    }

    /// <summary>
    /// 更新现有的物料类型
    /// </summary>
    /// <param name="id">物料的唯一标识符</param>
    /// <param name="materialType">要更新的物料类型对象</param>
    /// <returns>无内容</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMaterialType(Guid id, [FromBody] MaterialType materialType)
    {
        if (id != materialType.Id)
        {
            return BadRequest("Invalid material type data.");
        }

        try
        {
            await _materialTypeService.UpdateMaterialTypeAsync(materialType);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// 删除物料类型
    /// </summary>
    /// <param name="id">物料的唯一标识符</param>
    /// <returns>无内容</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMaterialType(Guid id)
    {
        try
        {
            await _materialTypeService.DeleteMaterialTypeAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}