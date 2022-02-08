using BackendApi.Models.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContentController : ControllerBase
{
    private readonly ContentConfiguration _contentConfiguration;

    public ContentController(ContentConfiguration contentConfiguration)
    {
        _contentConfiguration = contentConfiguration;
    }

    [HttpGet]
    [Route("get")]
    public IActionResult Get()
    {
        return Ok(_contentConfiguration.Display);
    }
}
