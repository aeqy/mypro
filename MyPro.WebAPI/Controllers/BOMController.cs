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

    public BOMController(CreateBOM createBom, GetBOM getBom)
    {
        _createBOM = createBom;
        _getBom = getBom;
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
}