namespace PRG_Game.Models;

using Players;
using Helpers;
using Interfaces;

using static Common.ApplicationConstants.Stats;
using static Common.ApplicationConstants.Symbols;
using static Common.ApplicationConstants.Multipliers;

internal class Monster : Point, ICharacter
{
    private readonly Wall _wall;
    private readonly Random _random;

    public Monster(Wall wall)
        : base(wall.LeftX, wall.TopY)
    {
        this._wall = wall;
        this._random = new Random();
        this.Setup();
    }

    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    public int Range { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Damage { get; set; }


    private void Setup()
    {
        this.Strength = this._random.Next(MonsterMinStrength, MonsterMaxStrength);
        this.Agility = this._random.Next(MonsterMinAgility, MonsterMaxAgility);
        this.Intelligence = this._random.Next(MonsterMinIntelligence, MonsterMaxIntelligence);
        this.Range = MonsterRange;
        this.Health = this.Strength * StrengthMultiplier;
        this.Mana = this.Intelligence * IntelligenceMultiplier;
        this.Damage = this.Agility * AgilityMultiplier;

    }

    public void SetRandomPosition(ICollection<Monster> monsterPositions, Point playerPosition)
    {
        this.LeftX = this._random.Next(2, this._wall.LeftX - 2);
        this.TopY = this._random.Next(2, this._wall.TopY - 2);

        bool isPointTaken = monsterPositions
            .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY)
              || (playerPosition.LeftX == this.LeftX && playerPosition.TopY == this.TopY);

        while (isPointTaken)
        {
            this.LeftX = this._random.Next(2, this._wall.LeftX - 2);
            this.TopY = this._random.Next(2, this._wall.TopY - 2);

            isPointTaken = monsterPositions
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
        }

        this.Draw(MonsterSymbol);
    }

    public void Move(Player playerPosition, ICollection<Monster> monsterPositions)
    {
        ConsoleHelper.ReplaceSymbolAtPosition(this.LeftX, this.TopY, BoardSymbol);
        if (this.LeftX > playerPosition.LeftX)
        {
            this.LeftX--;
            if (this.IsMonsterPoint(monsterPositions)
                || this.IsPlayerPosition(playerPosition))
            {
                this.LeftX++;
            }
        }
        else if (this.LeftX < playerPosition.LeftX)
        {
            this.LeftX++;
            if (this.IsMonsterPoint(monsterPositions)
                || this.IsPlayerPosition(playerPosition))
            {
                this.LeftX--;
            }
        }
        if (this.TopY > playerPosition.TopY)
        {
            this.TopY--;
            if (this.IsMonsterPoint(monsterPositions)
                || this.IsPlayerPosition(playerPosition))
            {
                this.TopY++;
            }
        }
        else if (this.TopY < playerPosition.TopY)
        {
            this.TopY++;
            if (this.IsMonsterPoint(monsterPositions)
                || this.IsPlayerPosition(playerPosition))
            {
                this.TopY--;
            }
        }
        ConsoleHelper.ReplaceSymbolAtPosition(this.LeftX, this.TopY, MonsterSymbol);

        if (this.IsNextToPlayer(playerPosition))
        {
            this.Attack(playerPosition);
        }
    }

    public bool IsMonsterPoint(ICollection<Monster> monsterPositions)
    {
        foreach (var monsterPosition in monsterPositions)
        {
            if (!monsterPosition.Equals(this) &&
                monsterPosition.TopY == this.TopY &&
                monsterPosition.LeftX == this.LeftX)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsPlayerPosition(Point playerPosition)
    {
        return playerPosition.LeftX == this.LeftX && playerPosition.TopY == this.TopY;
    }

    private bool IsNextToPlayer(Point playerPosition)
    {
        int leftDiff = Math.Abs(playerPosition.LeftX - this.LeftX);
        int topDiff = Math.Abs(playerPosition.TopY - this.TopY);

        return (leftDiff == 0 && topDiff == 1) || (leftDiff == 1 && topDiff == 0||leftDiff==1&&topDiff==1);
    }

    private void Attack(Player player)
    {
        player.Health -= this.Damage;
        ConsoleHelper.ReplaceTextAtPosition(8,0,player.Health.ToString()+EmptySpace);
    }
}
