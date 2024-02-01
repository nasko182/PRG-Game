namespace PRG_Game.Common;

internal static class ApplicationConstants
{
    internal static class Symbols
    {
        internal const char WallSymbol = '\u25A0';
        internal const char BoardSymbol = '▒';
        internal const char WarriorSymbol = '*';
        internal const char ArcherSymbol = '@';
        internal const char MageSymbol = '#';
        internal const char MonsterSymbol = '◙';
        internal const char EmptySpace = ' ';
    }

    internal static class Player
    {
        internal const int InitialLeftX = 1;
        internal const int InitialTopY = 2;

        internal const int InitialRemainingPoints = 3;
    }

    internal static class Multipliers
    {
        internal const int StrengthMultiplier = 5;
        internal const int IntelligenceMultiplier = 3;
        internal const int AgilityMultiplier = 2;
    }

    internal static class CharacterTypes
    {
        internal const string WarriorType = "Warrior";
        internal const string ArcherType = "Archer";
        internal const string MageType = "Mage";
    }

    internal static class CharacterSelect
    {
        internal const int Left = 18;
        internal const int Top = 9;
    }

    internal static class InGame
    {
        internal const int UserChoiceLeftX = 0;
        internal const int UserChoiceTopY = 13;
    }

    internal static class Stats
    {
        internal const int WarriorStrength = 3;
        internal const int WarriorAgility = 3;
        internal const int WarriorIntelligence = 0;
        internal const int WarriorRange = 1;

        internal const int ArcherStrength = 2;
        internal const int ArcherAgility = 4;
        internal const int ArcherIntelligence = 0;
        internal const int ArcherRange = 2;

        internal const int MageStrength = 2;
        internal const int MageAgility = 1;
        internal const int MageIntelligence = 3;
        internal const int MageRange = 3;

        internal const int MonsterMaxStrength = 4;
        internal const int MonsterMaxAgility = 4;
        internal const int MonsterMaxIntelligence = 4;
        internal const int MonsterMinStrength = 1;
        internal const int MonsterMinAgility = 1;
        internal const int MonsterMinIntelligence = 1;
        internal const int MonsterRange = 1;
    }
}
