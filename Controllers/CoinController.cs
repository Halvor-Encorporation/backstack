using Microsoft.AspNetCore.Mvc;
using backstack.Models;
using backstack.Services;

namespace backstack.Controllers;

[ApiController]
[Route("[controller]")]
public class CoinController : ControllerBase
{
    internal ICoinService _coinService;
    IEmailSender _emailSender;
    public CoinController(ICoinService coinService, IEmailSender emailSender) 
    {
        _coinService = coinService;
        _emailSender = emailSender;
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

    [HttpGet]
    [Route("sendMail")]
    public IActionResult SendMail()
    {
        _emailSender.SendEmailAsync("ecschoye@stud.ntnu.no", "Tilbakestill passord", "Send en melding til Halvor, så vil han tilbakestille passordet ditt.");
        return Ok("Mail sent");
    }

}
