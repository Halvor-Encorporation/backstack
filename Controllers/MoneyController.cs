using Microsoft.AspNetCore.Mvc;

namespace backstack.Controllers;

[ApiController]
[Route("[controller]")]
public class MoneyController : ControllerBase
{

    public MoneyController()
    {
       
    }

    

    [HttpGet]
    [Route("Halvor/{money}")]

    public IActionResult Halvor(int money)
    {
        return Ok($"Halvor has {money} HalvorCoins.");
    }

}
