namespace PRG_Game.Models.Players;

using Models;

using static Common.ApplicationConstants.Stats;
using static Common.ApplicationConstants.Symbols;
using static Common.ApplicationConstants.CharacterTypes;

internal class Archer : Player
{
    public Archer(Wall wall)
    : base(wall,ArcherSymbol,ArcherType)
    {
        this.Strength = ArcherStrength;
        this.Agility = ArcherAgility;
        this.Intelligence = ArcherIntelligence;
        this.Range = ArcherRange;
        this.Setup();
    }
}