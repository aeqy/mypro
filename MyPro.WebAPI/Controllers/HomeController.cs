using Microsoft.AspNetCore.Mvc;

namespace MyPro.WebAPI.Controllers;

[ApiController]
[Route("/1/·")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Welcome to MyPro API!");
    }
}