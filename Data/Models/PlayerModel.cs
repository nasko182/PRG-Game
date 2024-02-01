namespace PRG_Game.Data.Models;

using System.ComponentModel.DataAnnotations;

public class PlayerModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Type { get; set; } = null!;

    [Required]
    public int Health { get; set; }

    [Required]
    public int Mana { get; set; }

    [Required]
    public int Damage { get; set; }

    [Required]
    public int Strength { get; set; }

    [Required]
    public int Agility { get; set; }

    [Required]
    public int Intelligence { get; set; }

    [Required]
    public int Range { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

}
