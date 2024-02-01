namespace PRG_Game.Services.Interfaces;

using Models;
using Models.Players;

public interface IPlayerService
{
    void AddPlayerAsync(Player player);
}
