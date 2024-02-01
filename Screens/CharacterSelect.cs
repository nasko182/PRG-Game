namespace PRG_Game.Screens;

using System;
using System.Reflection;

using Models;
using Helpers;
using Models.Players;

using static Common.OutputMessages.CharacterSelect;
using static Common.ExceptionMessages.CharacterSelect;
using static Common.ApplicationConstants.CharacterSelect;


public class CharacterSelect
{
    private Player? _player;
    private readonly Wall _wall;
    public CharacterSelect (Wall wall)
    {
        this._wall = wall;
    }

    public Player Show()
    {
        Console.Clear();
        Console.Write(PickCharacterMessage);

        int choice = ConsoleHelper.CheckKeyIntValue(1, 3);

        switch (choice)
        {
            case 1:
                this._player = new Warrior(this._wall);
                break;
            case 2:
                this._player = new Archer(this._wall);
                break;
            case 3:
                this._player = new Mage(this._wall);
                break;
        }

        Console.WriteLine(string.Format(YourSelectionMessage,this._player!.GetType().Name));

        ConsoleKeyInfo userInput = ConsoleHelper.CheckYesNoResponse(ChooseToBuffMessage);
        if (userInput.Key == ConsoleKey.Y)
        {
            ConsoleHelper.ReplaceSymbolAtPosition(Console.CursorLeft - 1, Console.CursorTop, 'Y');
            this.BuffStats();
        }

        Console.Clear();
        return this._player;
    }

    private void BuffStats()
    {
        Console.Write(string.Format(RemainingPointsMessage,this._player!.RemainingPoints));

        this.AddPoints("Strength");
        if (this._player.RemainingPoints > 0)
        {
            this.AddPoints("Agility");
        }
        if (this._player.RemainingPoints > 0)
        {
            this.AddPoints("Intelligence");
        }

    }

    private void AddPoints(string stat)
    {
        Console.Write(string.Format(AddToStatMessage,stat));
        int points = ConsoleHelper.CheckKeyIntValue(0, this._player!.RemainingPoints);


        PropertyInfo? property = typeof(Player).GetProperty(stat);
        if (property != null)
        {
            this._player.UpdateRemainingPoints(points);
            ConsoleHelper.ReplaceTextAtPosition(Left, Top, this._player.RemainingPoints.ToString());

            var currentValue = (int)(property.GetValue(this._player!) ?? false);
            property.SetValue(this._player, currentValue + points);
        }
        else
        {
            throw new ArgumentException(InvalidStatMessage);
        }
    }
}

