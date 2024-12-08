using Microsoft.AspNetCore.Mvc;
using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;

namespace MyPro.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MaterialTypeController: ControllerBase
{
    private readonly IMaterialTypeRepository _materialTypeRepository;

    public MaterialTypeController(IMaterialTypeRepository materialTypeRepository)
    {
        _materialTypeRepository = materialTypeRepository;
    }
    
    [HttpPost]
    public IActionResult AddMaterialType([FromBody] MaterialType materialType)
    {
        _materialTypeRepository.AddMaterialType(materialType);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMaterialType(Guid id, [FromBody] MaterialType materialType)
    {
        if (id != materialType.Id)
        {
            return BadRequest("ID 不匹配");
        }
        
        var existingMaterial = _materialTypeRepository.GetMaterialTypeById(id);
        if (existingMaterial == null)
        {
            return NotFound("Material not found.");
        }

        existingMaterial.Code = materialType.Code;
        existingMaterial.Name = materialType.Name;
        existingMaterial.Specification = materialType.Specification;
        existingMaterial.Description = materialType.Description;
        
        
        _materialTypeRepository.UpdateMaterialType(materialType);
        return Ok();

        
    }
    [HttpDelete("id")]
    public IActionResult DeleteMaterialType(Guid id)
    {
        _materialTypeRepository.DeleteMaterialType(id);
        return Ok();
    }

    [HttpGet("id")]
    public IActionResult GetMaterialTypeById(Guid id)
    {
        var materialType = _materialTypeRepository.GetMaterialTypeById(id);
        if (materialType == null)
        {
            return NotFound();
        }
        return Ok(materialType);
    }

    [HttpGet]
    public IActionResult GetAllMaterialType()
    {
        var materialTypes = _materialTypeRepository.GetMaterialTypes();
        return Ok(materialTypes);
    }
}