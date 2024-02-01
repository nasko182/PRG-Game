namespace PRG_Game.Helpers;

using static Common.ApplicationConstants.Symbols;

internal static class ConsoleHelper
{
    internal static void ClearAtPosition(int left, int top)
    {
        Console.SetCursorPosition(left, top);
        Console.Write(EmptySpace);
        Console.SetCursorPosition(left, top);
    }
    internal static void ClearRow(int left, int top)
    {
        Console.SetCursorPosition(left, top);
        Console.Write(new string(EmptySpace, Console.BufferWidth - left));
        Console.SetCursorPosition(left, top);
    }
    internal static void ClearRow(int left, int top, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.SetCursorPosition(left, top + i);
            Console.Write(new string(EmptySpace, Console.BufferWidth - left));
        }
        Console.SetCursorPosition(left, top);
    }
    internal static void ReplaceSymbolAtPosition(int left, int top, char symbol)
    {
        int cursorTop = Console.CursorTop;
        int cursorLeft = Console.CursorLeft;

        Console.SetCursorPosition(left, top);
        Console.Write(symbol);
        Console.SetCursorPosition(cursorLeft, cursorTop);
    }
    internal static void ReplaceTextAtPosition(int left, int top, string text)
    {
        int cursorTop = Console.CursorTop;
        int cursorLeft = Console.CursorLeft;

        Console.SetCursorPosition(left, top);
        Console.Write(text);
        Console.SetCursorPosition(cursorLeft + text.Length - 1, cursorTop);
    }
    internal static int CheckKeyIntValue(int minValue, int maxValue)
    {
        int currentLeftX = Console.CursorLeft;
        int choice;

        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (!char.IsDigit(keyInfo.KeyChar))
            {
                ClearAtPosition(Console.CursorLeft - 1, Console.CursorTop);
                continue;
            }
            if (!int.TryParse(keyInfo.KeyChar.ToString(), out choice)
                || choice < minValue || choice > maxValue)
            {
                ClearAtPosition(Console.CursorLeft - 1, Console.CursorTop);
                continue;
            }
            break;

        } while (true);

        return choice;
    }
    internal static ConsoleKeyInfo CheckYesNoResponse(string message)
    {
        Console.WriteLine(message);
        Console.Write("Response (Y\\N): ");

        ConsoleKeyInfo userInput;
        int currentLeftX = Console.CursorLeft;
        do
        {
            userInput = Console.ReadKey();
            if (!char.IsLetter(userInput.KeyChar))
            {
                Console.SetCursorPosition(currentLeftX, Console.CursorTop);
                continue;
            }
            break;
        } while (true) ;

        while (userInput.Key != ConsoleKey.Y && userInput.Key != ConsoleKey.N)
        {
            ClearAtPosition(Console.CursorLeft - 1, Console.CursorTop);
            userInput = Console.ReadKey();
        }

        return userInput;
    }
}
