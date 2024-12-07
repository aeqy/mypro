using Microsoft.AspNetCore.Mvc;
using MyPro.Application.Interfaces;
using MyPro.Domain.Entities;

namespace MyPro.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TextEntryController: ControllerBase
{
    private readonly ITextEntryRepository _repository;

    public TextEntryController(ITextEntryRepository repository)
    {
        _repository = repository;
    }
    
    [HttpPost]
    public IActionResult AddTextEntry([FromBody] string content)
    {
        var textEntry =new TextEntry { Content = content };
        _repository.AddTextEntry(textEntry);
        return Ok();
    }

    [HttpGet("count")]
    public IActionResult GetTextEntriesCount()
    {
        var count = _repository.GetTextEntryCount();
        return Ok(count);
    }
}