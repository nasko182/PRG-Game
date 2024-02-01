namespace PRG_Game.Common;

internal static class OutputMessages
{
    internal static class MainMenu
    {
        internal const string WelcomeMessage = "Welcome!\nPress any key to play...";
    }

    internal static class CharacterSelect
    {
        internal const string PickCharacterMessage = "Choose character type:\nOptions:\n1) Warrior\n2) Archer\n3) Mage\nYour pick is: ";
        internal const string YourSelectionMessage = "\nYou selected {0}";
        internal const string ChooseToBuffMessage = "Would you like to buff up your stats before starting? (Limit: 3 points total)";
        internal const string RemainingPointsMessage = "\nRemaining Points: {0}";
        internal const string AddToStatMessage = "\nAdd to {0}: ";
    }

    internal static class InGame
    {
        internal const string ChooseActionMessage = "Choose action\n1) Attack\n2) Move";
        internal const string NoAvailableTargetsMessage = "No available targets in your range. Press any key to continue...";
        internal const string ChooseMonsterToAttackMessage = "\nWhich one to attack: ";
        internal const string ChooseStepsCountMessage = "\nHow many steps do you want to do: ";
        internal const string YourRangeMessage = "Your range is {0}.";
        internal const string ChooseDirectionMessage = "What is your next direction: ";
    }

    internal static class Exit
    {
        internal const string RestartGameMessage = "Would you like to restart?";
        internal const string ExitGameMessage = "Game Over";
    }

    internal static class Player
    {
        internal const string StatsMessage = "Health: {0}        Mana: {1}";
        internal const string DisplayTargetMessage = "{0}) target with remaining blood {1}";
    }
}
