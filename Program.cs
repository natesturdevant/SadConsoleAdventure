using SadConsole.Configuration;
using SadConsoleGame;

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
    
    //nothing
    
}
