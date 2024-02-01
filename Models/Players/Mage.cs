namespace PRG_Game.Models.Players;

using Models;

using static Common.ApplicationConstants.Stats;
using static Common.ApplicationConstants.Symbols;
using static Common.ApplicationConstants.CharacterTypes;

internal class Mage : Player
{
    public Mage(Wall wall)
        : base(wall, MageSymbol,MageType)
    {
        this.Strength = MageStrength;
        this.Agility = MageAgility;
        this.Intelligence = MageIntelligence;
        this.Range = MageRange;
        this.Setup();
    }
}
