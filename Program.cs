using SadConsole.Configuration;
using SadConsoleGame;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

Settings.WindowTitle = "PLATO 1976";



Builder configuration = new Builder()
    .SetScreenSize(120, 38)
    .SetStartingScreen<RootScreen>()
    .IsStartingScreenFocused(true)
    .OnStart(Startup)
    ;


Game.Create(configuration);
Game.Instance.Run();
Game.Instance.Dispose();


static void Startup(object? sender, GameHost host)
{
    //nothing here.
    /*
    Console _debugger = new Console(10, 10);
    //_debugger = new ScreenSurface(10, 10);
    _debugger.Position = (1, 1);
    _debugger.Surface.DefaultBackground = Color.AnsiCyan;
    _debugger.SortOrder = 0;
    _debugger.Cursor.Position = (1, 1);
    _debugger.Cursor.IsVisible = true;
    Game.Instance.Screen.Children.Add(_debugger);
    */




}

