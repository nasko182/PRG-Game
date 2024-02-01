namespace PRG_Game.Screens;

using Helpers;

using static Common.OutputMessages.Exit;

internal class Exit
{
    internal bool AskUserForRestart()
    {
        ConsoleKeyInfo userInput = ConsoleHelper.CheckYesNoResponse(RestartGameMessage);
        if (userInput.Key == ConsoleKey.Y)
        {
            ConsoleHelper.ReplaceSymbolAtPosition(Console.CursorLeft - 1, Console.CursorTop, 'Y');
            return true;
        }

        this.ExitGame();
        return false;
    }
    private void ExitGame()
    {
        Console.SetCursorPosition(20, 10);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(ExitGameMessage);
        Console.BackgroundColor = ConsoleColor.White;
        Environment.Exit(0);
    }
}
