using SadConsole.Components;
using SadConsole.Input;
using SadConsole.Instructions;
using SadConsole.UI;


namespace SadConsoleGame;


internal class RootScreen : ScreenObject
{
    public Map _map;
    public Map map;

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
                
                // Create an instance of CustomConsole with a width of 118 and height of 5
                    CustomConsole customConsole = new CustomConsole(118, 5);
                   

                // Set the position of the console on the screen
                
                customConsole.Position = new Point(1, 33); // Set the position as needed
               
                //customConsole.LoadKeywordMapping();
                    customConsole.IsFocused = true;
               

                //customConsole.LoadKeywordMapping(); 
                    Game.Instance.Screen.Children.Add(customConsole);
                customConsole.OnConsoleClosed += (sender, e) => Game.Instance.Screen.Children.Remove(customConsole);

                




                handled = true;
  
            }
        }

        

        else if (keyboard.IsKeyPressed(Keys.M))
        {
            if (_map.IsAtEdge(_map.UserControlledObject.Position))
            {
                _map.SurfaceObject.Print(1,1,"Yes!");
                handled = true;
            }
        }

        else if (keyboard.IsKeyDown(Keys.B))
        {
          
            Map map = _map;
            MapDrawing mappo = new MapDrawing();
            MapDrawing mapDrawing = mappo;

           // map.SurfaceObject.Clear();
            //map.SurfaceObject.Print(5, 5, $"{map.WorldPosition}");
            
            CustomConsole check = new CustomConsole(7,4);

            map.SurfaceObject.Children.Add(check);
            
            check.Print(0, 0, $"{map.WorldPosition}    ");
            check.Print(0,1,$"{map.UserControlledObject.Position}");
            check.Print(0, 2, $"{map.charGlyph.ToString()}");
           
            handled = true;
            
           

        }

        else if (keyboard.IsKeyDown(Keys.L))
        {
            
        }

        return handled;
    }
}