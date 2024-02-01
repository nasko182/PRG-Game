namespace PRG_Game.Screens;

using static Common.OutputMessages.MainMenu;

internal class MainMenu
{
    internal static void Show()
    {
        Console.Write(WelcomeMessage);
        Console.ReadKey();
    }
}
