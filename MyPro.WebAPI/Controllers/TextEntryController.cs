using Microsoft.AspNetCore.Mvc;
using MyPro.Domain.Entities;
using MyPro.Domain.Interfaces;

namespace MyPro.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TextEntryController(ITextEntryRepository repository) : ControllerBase
{
    [HttpPost]
    public IActionResult AddTextEntry([FromBody] string content)
    {
        var textEntry =new TextEntry { Content = content };
        repository.AddTextEntry(textEntry);
        return Ok();
    }

    [HttpGet("count")]
    public IActionResult GetTextEntriesCount()
    {
        var count = repository.GetTextEntryCount();
        return Ok(count);
    }
}