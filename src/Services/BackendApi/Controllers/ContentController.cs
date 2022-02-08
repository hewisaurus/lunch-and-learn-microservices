using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContentController : ControllerBase
{
    [HttpGet]
    [Route("get")]
    public IActionResult Get()
    {
        return Ok("Some content from version 1 of the backend API");
    }
}
