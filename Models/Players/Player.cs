namespace PRG_Game.Models.Players;

using Helpers;
using Interfaces;

using static Common.OutputMessages.Player;
using static Common.ApplicationConstants.Player;
using static Common.ApplicationConstants.Symbols;
using static Common.ApplicationConstants.Multipliers;

public abstract class Player : Point, ICharacter
{
    private readonly Wall _wall;

    private int _health;
    private int _nextLeftX;
    private int _nextTopY;
    private readonly ICollection<Monster> _monsters;
    private readonly ICollection<Monster> _nearbyMonsters;

    private readonly char _characterSymbol;

    protected Player(Wall wall, char characterSymbol, string type)
        : base(InitialLeftX, InitialTopY)
    {
        this._wall = wall;
        this._characterSymbol = characterSymbol;
        this.Type = type;
        this.CreatedAt = DateTime.UtcNow;
        this._monsters = new HashSet<Monster>();
        this._nearbyMonsters = new HashSet<Monster>();
    }
    public string Type { get; }
    public int Health
    {
        get => this._health;
        set
        {
            if (value < 0)
            {
                value = 0;
            }

            this._health = value;
        }
    }
    public int Mana { get; set; }
    public int Damage { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    public int Range { get; set; }
    public int RemainingPoints { get; private set; }
    public DateTime CreatedAt { get; }
    public int NearbyMonstersCount => this._nearbyMonsters.Count;

    protected void Setup()
    {
        this.Health = this.Strength * StrengthMultiplier;
        this.Mana = this.Intelligence * IntelligenceMultiplier;
        this.Damage = this.Agility * AgilityMultiplier;

        this.RemainingPoints = InitialRemainingPoints;
    }

    public override string ToString()
    {
        return string.Format(StatsMessage,this.Health,this.Mana);
    }

    public bool DisplayEnemies()
    {
        this.GetMonstersInRange();
        if (this._nearbyMonsters.Count != 0)
        {
            int counter = 0;
            foreach (var monster in this._nearbyMonsters)
            {
                ConsoleHelper.ReplaceTextAtPosition(0, Console.CursorTop + counter, string.Format(DisplayTargetMessage,counter,monster.Health));
                counter++;
            }

            Console.CursorTop += counter - 1;
            return true;
        }

        return false;
    }

    public void UpdateRemainingPoints(int points)
    {
        this.RemainingPoints -= points;
    }

    public bool Move(Point direction, int steps)
    {
        this.GetNextPoint(direction, steps);

        Point newPlayerPlace = new Point(this._nextLeftX, this._nextTopY);

        if (this._wall.IsPointOfWall(newPlayerPlace) || this.IsMonsterPoint())
        {
            return false;
        }

        newPlayerPlace.Draw(this._characterSymbol);
        this.Draw(BoardSymbol);
        this.LeftX = this._nextLeftX;
        this.TopY = this._nextTopY;

        this.MoveMonsters();
        this.CreateMonster();
        return true;
    }

    public void Attack(int choice)
    {
        Monster monster = this._nearbyMonsters.ToArray()[choice];
        monster.Health -= this.Damage;
        if (monster.Health < 1)
        {
            this._nearbyMonsters.Remove(monster);
            this._monsters.Remove(monster);
            ConsoleHelper.ReplaceSymbolAtPosition(monster.LeftX, monster.TopY, BoardSymbol);
        }

        this.MoveMonsters();
        this.CreateMonster();
    }

    public void CreateCharacter()
    {
        this.Draw(this._characterSymbol);
    }

    private void CreateMonster()
    {
        Monster monster = new Monster(this._wall);
        monster.SetRandomPosition(this._monsters, this);
        this._monsters.Add(monster);
    }

    private void GetMonstersInRange()
    {
        foreach (Monster monster in this._monsters)
        {
            if (Math.Abs(monster.LeftX - this.LeftX) <= this.Range && Math.Abs(monster.TopY - this.TopY) <= this.Range)
            {
                this._nearbyMonsters.Add(monster);
            }
        }
    }

    private void GetNextPoint(Point direction, int steps)
    {
        for (int i = 1; i <= steps; i++)
        {
            this._nextLeftX = this.LeftX + direction.LeftX * i;
            this._nextTopY = this.TopY + direction.TopY * i;
            if (this.IsMonsterPoint()
                || this._wall.IsPointOfWall(new Point(this._nextLeftX, this._nextTopY)))
            {
                if (i > 1)
                {
                    this._nextLeftX -= direction.LeftX;
                    this._nextTopY -= direction.TopY;
                }
                break;
            }
        }
    }

    private void MoveMonsters()
    {
        foreach (Monster monster in this._monsters)
        {
            monster.Move(this, this._monsters);
        }
    }

    private bool IsMonsterPoint()
    {
        return this._monsters.Any(m => m.LeftX == this._nextLeftX && m.TopY == this._nextTopY);
    }

}
