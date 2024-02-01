namespace PRG_Game.Core;

using Enums;
using Models;
using Models.Players;
using Screens;
using Services.Interfaces;

internal class Engine
{
    private Screen? _currentScreen;
    private Player? _player;

    private readonly CharacterSelect? _characterSelect;
    private readonly InGame? _inGame;
    private readonly Exit? _exit;
    private readonly Wall _wall;
    private readonly IPlayerService _playerService;


    public Engine(IPlayerService playerService)
    {
        this._wall = new Wall(10, 10);
        this._currentScreen = Screen.MainMenu;
        this._characterSelect = new CharacterSelect(this._wall);
        this._inGame = new InGame();
        this._exit = new Exit();
        this._playerService = playerService;
    }

    public void Start()
    {
        while (true)
        {
            switch (this._currentScreen)
            {
                case Screen.MainMenu:

                    MainMenu.Show();
                    this._currentScreen = Screen.CharacterSelect;
                    break;
                case Screen.CharacterSelect:

                    Console.Clear();
                    this._player = this._characterSelect!.Show();
                    this._currentScreen = Screen.InGame;
                    this._playerService.AddPlayerAsync(this._player);
                    break;
                case Screen.InGame:

                    Console.Clear();
                    this._inGame!.Show(this._player!,this._wall);
                    this._currentScreen = Screen.Exit;
                    break;
                case Screen.Exit:

                    this._exit!.AskUserForRestart();
                    this._currentScreen = Screen.CharacterSelect;
                    break;
            }
        }
    }
}
