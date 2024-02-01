namespace PRG_Game.Utilities;

using System;
using System.Text;

public static class ConsoleWindow
{
    public static void CustomizeConsole()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.SetWindowSize(80,30);
        Console.SetBufferSize(80,30);
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
    }
}
