namespace PRG_Game.Screens;

using System;

using Enums;
using Models;
using Helpers;

using static Common.OutputMessages.InGame;
using static Common.ApplicationConstants.InGame;
using Models.Players;

internal class InGame
{
    private readonly Point[] _pointsOfDirections;
    private Direction _direction;

    public InGame()
    {
        this._pointsOfDirections = new Point[8];
    }

    public void Show(Player player, Wall wall)
    {
        Console.WriteLine($"{player}");
        wall.InitializeWallBorders();
        player.CreateCharacter();
        this.CreateDirections();

        Console.SetCursorPosition(UserChoiceLeftX, UserChoiceTopY);
        Console.WriteLine(ChooseActionMessage);

        while (player.Health > 0)
        {
            this.ChooseAction(player);
        }
    }

    private void ChooseAction(Player player)
    {
        int choice = ConsoleHelper.CheckKeyIntValue(1, 2);

        switch (choice)
        {
            case 1:
                if (player.DisplayEnemies())
                {
                    player.Attack(ChooseMonster(player.NearbyMonstersCount));
                }
                else
                {
                    ConsoleHelper.ReplaceTextAtPosition(0, Console.CursorTop, NoAvailableTargetsMessage);
                    Console.ReadKey();
                }
                break;
            case 2:
                int steps = GetStepsCount(player);
                while (!this.GetNextDirection())
                {
                    ConsoleHelper.ClearRow(0, Console.CursorTop);
                };
                while (!player.Move(this._pointsOfDirections[(int)this._direction], steps))
                {
                    ConsoleHelper.ClearRow(0, Console.CursorTop);
                    while (!this.GetNextDirection())
                    {
                        ConsoleHelper.ClearRow(0, Console.CursorTop);
                    }
                }
                break;
        }

        ConsoleHelper.ClearRow(0, 16, 3);
    }

    private static int ChooseMonster(int monstersCount)
    {
        Console.Write(ChooseMonsterToAttackMessage);
        return ConsoleHelper.CheckKeyIntValue(0, monstersCount - 1);
    }

    private static int GetStepsCount(Player player)
    {
        int range;
        ConsoleHelper.ReplaceTextAtPosition(0, Console.CursorTop, String.Format(YourRangeMessage,player.Range));
        if (player.Range > 1)
        {
            Console.Write(ChooseStepsCountMessage);
            range = ConsoleHelper.CheckKeyIntValue(1, player.Range);
        }
        else
        {
            range = player.Range;
        }
        Console.WriteLine();
        return range;
    }

    private void CreateDirections()
    {
        this._pointsOfDirections[(int)Direction.East] = new Point(1, 0);
        this._pointsOfDirections[(int)Direction.SouthEast] = new Point(1, 1);
        this._pointsOfDirections[(int)Direction.South] = new Point(0, 1);
        this._pointsOfDirections[(int)Direction.SouthWest] = new Point(-1, 1);
        this._pointsOfDirections[(int)Direction.West] = new Point(-1, 0);
        this._pointsOfDirections[(int)Direction.NorthWest] = new Point(-1, -1);
        this._pointsOfDirections[(int)Direction.North] = new Point(0, -1);
        this._pointsOfDirections[(int)Direction.NorthEast] = new Point(1, -1);
    }

    private bool GetNextDirection()
    {
        Console.Write(ChooseDirectionMessage);
        ConsoleKeyInfo userInput = Console.ReadKey(true);

        switch (userInput.Key)
        {
            case ConsoleKey.D:
                this._direction = Direction.East;
                return true;
            case ConsoleKey.A:
                this._direction = Direction.West;
                return true;
            case ConsoleKey.S:
                this._direction = Direction.South;
                return true;
            case ConsoleKey.W:
                this._direction = Direction.North;
                return true;
            case ConsoleKey.E:
                this._direction = Direction.NorthEast;
                return true;
            case ConsoleKey.Q:
                this._direction = Direction.NorthWest;
                return true;
            case ConsoleKey.X:
                this._direction = Direction.SouthEast;
                return true;
            case ConsoleKey.Z:
                this._direction = Direction.SouthWest;
                return true;
            default:
                return false;
        }
    }
}
