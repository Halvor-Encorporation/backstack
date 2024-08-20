using backstack.Models;


namespace backstack.Services;

public interface ICoinService
{
    List<Money> GetAllCoins();
    int GetCoinsById(string userId);
    void AddCoins(string userId, int amount);
}
