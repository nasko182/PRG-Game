namespace PRG_Game.Services;

using Data;
using Data.Models;
using Models;
using Interfaces;
using Models.Players;

public class PlayerService : IPlayerService
{
    private readonly ApplicationDbContext _dbContext;

    public PlayerService(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }


    public async void AddPlayerAsync(Player player)
    {
        var model = new PlayerModel
        {
            Type = player.Type,
            Health = player.Health,
            Mana = player.Mana,
            Damage = player.Damage,
            Strength = player.Strength,
            Agility = player.Agility,
            Intelligence = player.Agility,
            Range = player.Range,
            CreatedAt = player.CreatedAt
        };

        await this._dbContext.Players.AddAsync(model);
        await this._dbContext.SaveChangesAsync();
    }
}
