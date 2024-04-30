using SadConsole.Input;

namespace SadConsoleGame;

internal class RootScreen : ScreenObject
{
    private Map _map;
    

    public RootScreen()
    {
        _map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 6);
        Children.Add(_map.SurfaceObject);

    
      
        
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;

        if (keyboard.IsKeyPressed(Keys.Up)||(keyboard.IsKeyPressed(Keys.W)))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Up, _map);
            handled = true;
        }
        else if (keyboard.IsKeyPressed(Keys.Down) || (keyboard.IsKeyPressed(Keys.S)))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Down, _map);
            handled = true;
        }

        else if (keyboard.IsKeyPressed(Keys.Left) || (keyboard.IsKeyPressed(Keys.A)))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Left, _map);
            handled = true;
        }
        else if (keyboard.IsKeyPressed(Keys.Right) || (keyboard.IsKeyPressed(Keys.D)))
        {
            _map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Right, _map);
            handled = true;
        }

        else if (keyboard.IsKeyPressed(Keys.T))
        {
            if (_map.IsMonsterNearby(_map.UserControlledObject.Position))
            {
                //add dialogue functionality here
               

                // First console
               
                Console console1 = new(116, 4);
                console1.Position = (1, 33);
                console1.Surface.DefaultBackground = Color.AnsiCyan;
                //console1.Clear();
                console1.Print(1, 1, "Ask about...");
                console1.Cursor.Position = (1, 2);
                console1.Cursor.IsEnabled = true;
                console1.Cursor.IsVisible = true;
                //console1.Cursor.MouseClickReposition = true;
                console1.IsFocused = true;
                Game.Instance.Screen.Children.Add(console1);
                //container.Children.Add(console1);
               
                handled = true;
            }
        }

        return handled;
    }
}