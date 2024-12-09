using Microsoft.AspNetCore.Mvc;
using MyPro.Application.Services;
using MyPro.Domain.Entities;

namespace MyPro.WebAPI.Controllers;

/// <summary>
/// 提供与 BOM（物料清单）相关的 API 控制器
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BomController : ControllerBase
{
    private readonly BomService _bomService;

    /// <summary>
    /// 初始化 BomController 类的新实例
    /// </summary>
    /// <param name="bomService">用于处理 BOM 业务逻辑的服务</param>
    public BomController(BomService bomService)
    {
        _bomService = bomService ?? throw new ArgumentNullException(nameof(bomService));
    }

    /// <summary>
    /// 获取使用指定物料的所有 BOM 的名称
    /// </summary>
    /// <param name="materialId">物料的唯一标识符</param>
    /// <returns>包含使用该物料的 BOM 名称的列表</returns>
    [HttpGet("material/{materialId}/boms")]
    public async Task<IActionResult> GetBoMsUsingMaterial(Guid materialId)
    {
        try
        {
            // 调用服务层方法获取 BOM 名称列表
            var bomNames = await _bomService.GetBoMsUsingMaterial(materialId);

            // 返回 200 OK 状态码和 BOM 名称列表
            return Ok(bomNames);
        }
        catch (Exception)
        {
            // 记录异常日志（此处省略具体日志记录实现）
            // 返回 500 内部服务器错误状态码和错误消息
            return StatusCode(500, "An error occurred while retrieving BOMs.");
        }
    }

    /// <summary>
    /// 获取指定物料在所有 BOM 中的总用量
    /// </summary>
    /// <param name="materialId">物料的唯一标识符</param>
    /// <returns>包含物料名称和总用量的字典</returns>
    [HttpGet("{materialId}/quantities")]
    public async Task<IActionResult> GetTotalQuantities(Guid materialId)
    {
        try
        {
            // 调用服务层方法计算物料的总用量
            var quantities = await _bomService.CalculateTotalQuantities(materialId);

            // 返回 200 OK 状态码和计算结果
            return Ok(quantities);
        }
        catch (Exception)
        {
            // 记录异常日志（此处省略具体日志记录实现）
            // 返回 500 内部服务器错误状态码和错误消息
            return StatusCode(500, "An error occurred while calculating quantities.");
        }
    }
    
    

    /// <summary>
    /// 添加BOM组件
    /// </summary>
    /// <param name="parentMaterialId"></param>
    /// <param name="childMaterialId"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddBomComponent(Guid parentMaterialId, Guid childMaterialId, int  quantity)
    {
        try
        {
            await _bomService.AddBomComponentAsync(parentMaterialId, childMaterialId, quantity);
            return Ok("Bom component added. 成功🏅");
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBomComponent(Guid bomComponentId, int quantity)
    {
        try
        {
            await _bomService.UpdateBomComponentAsync(bomComponentId,quantity);
            return Ok("BOM 组件更新成功🏅");
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}