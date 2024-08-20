using backstack.Data.Context;
using backstack.Models;

namespace backstack.Services;

public class CoinService : ICoinService
{
    private readonly MoneyContext _context;

    public CoinService(MoneyContext context)
    {
        _context = context;
    }

    

    // Example method to get all coins
    public List<Money> GetAllCoins()
    {
        return _context.Money.ToList();
    }

    // Example method to get a coin by ID
    public int GetCoinsById(string userId)
    {
        Money? money = _context.Money.Find(userId);
        if (money == null) return 0;
        return money.Amount;
    }

    // Example method to add a new coin
    public void AddCoins(string userId, int amount)
    {
        if (amount < 0) return;
        Money? money = _context.Money.Find(userId);
        if (money == null)
        {
            money = new Money {Id = userId, Amount = amount};
            _context.Money.Add(money);
        }
        else
        {
            money.Amount += amount;
        }
        _context.SaveChanges();
    }

    

}