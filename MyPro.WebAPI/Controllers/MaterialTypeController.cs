using Microsoft.AspNetCore.Mvc;
using MyPro.Domain.Entities;
using MyPro.Domain.Interfaces;

namespace MyPro.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaterialTypeController : ControllerBase
{
    private readonly IMaterialTypeService _materialTypeService;

    public MaterialTypeController(IMaterialTypeService materialTypeService)
    {
        _materialTypeService = materialTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var m = await _materialTypeService.GetAllMaterialTypesAsync();
        return Ok(m);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] MaterialType materialType)
    {
        if (materialType == null)
        {
            return BadRequest("Material type cannot be null.");
        }

        await _materialTypeService.AddMaterialTypeAsync(materialType);
        return CreatedAtAction(nameof(GetAll), new { id = materialType.Id }, materialType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] MaterialType materialType)
    {
        if (materialType == null || materialType.Id != id)
        {
            return BadRequest("Material type cannot be null.");
        }

        await _materialTypeService.UpdateMaterialTypeAsync(materialType);
        return NoContent();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(Guid id)
    {
        await _materialTypeService.DeleteMaterialTypeAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var m = await _materialTypeService.GetMaterialTypeByIdAsync(id);
        if (m == null) return NotFound();
        return Ok(m);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string keyword)
    {
        var m = await _materialTypeService.SearchAsync(keyword);
        return Ok(m);
    }
}