using Microsoft.AspNetCore.Mvc;

namespace backstack.Controllers;

[ApiController]
[Route("")]
public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStatus()
    {
        return Ok("Backend is running.");
    }
}
