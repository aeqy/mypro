using Microsoft.AspNetCore.Mvc;
using MyPro.Application.DTOs;
using MyPro.Application.Interfaces;
using MyPro.Application.UseCases;
using MyPro.Domain.Entities;

namespace MyPro.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BOMController: ControllerBase
{
    private readonly CreateBOM _createBOM;
    private readonly GetBOM _getBom;

    private readonly UpdateBOM _updateBom;
    private readonly DeleteBOM _deleteBom;
    public BOMController(CreateBOM createBom, GetBOM getBom, UpdateBOM updateBom, DeleteBOM deleteBom)
    {
        _createBOM = createBom;
        _getBom = getBom;
        _updateBom = updateBom;
        _deleteBom = deleteBom;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBOM([FromBody] BOMDto bomDto)
    {
        if (bomDto == null)
        {
            return BadRequest("BOMDto is null。");
        }
        
        var result = await _createBOM.Handle(bomDto);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var bom = await _getBom.Execute(id);

        if (bom == null)
        {
            return NotFound();
        }
        return Ok(bom);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] BOMDto bomDto)
    {
        if (bomDto == null)
        {
            return BadRequest("BOM data is null.");
        }

        try
        {
            var result = await _updateBom.ExecuteAsync(id, bomDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _deleteBom.ExecuteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}