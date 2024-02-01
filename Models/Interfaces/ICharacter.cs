namespace PRG_Game.Models.Interfaces;

internal interface ICharacter
{
    int Strength { get; set; }
    int Agility { get; set; }
    int Intelligence { get; set; }
    int Range { get; set; }
    int Health { get; set; }
    int Damage { get; set; }
}
