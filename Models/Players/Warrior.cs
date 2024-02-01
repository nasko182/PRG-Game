namespace PRG_Game.Models.Players;

using Models;

using static Common.ApplicationConstants.Stats;
using static Common.ApplicationConstants.Symbols;
using static Common.ApplicationConstants.CharacterTypes;

internal class Warrior : Player
{
    public Warrior(Wall wall)
        : base(wall, WarriorSymbol,WarriorType)
    {
        this.Strength = WarriorStrength;
        this.Agility = WarriorAgility;
        this.Intelligence = WarriorIntelligence;
        this.Range = WarriorRange;
        this.Setup();
    }
}
