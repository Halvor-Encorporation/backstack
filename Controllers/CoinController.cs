using Microsoft.AspNetCore.Mvc;
using backstack.Models;
using backstack.Services;

namespace backstack.Controllers;

[ApiController]
[Route("[controller]")]
public class CoinController : ControllerBase
{
    internal ICoinService _coinService;
    public CoinController(ICoinService coinService)
    {
       _coinService = coinService;
    }

    

    [HttpGet]
    [Route("All")]
    public IActionResult Halvor()
    {
        List<Money> coins = _coinService.GetAllCoins();
        return Ok(coins);
    }

    [HttpGet]
    [Route("/AddMoney/{userId}/{amount}")]

    public IActionResult AddMoney(string userId, int amount)
    {
        _coinService.AddCoins(userId, amount);
        return Ok();
    }

}
