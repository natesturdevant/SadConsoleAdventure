using SadConsole.Components;
using SadConsole.UI;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace SadConsoleGame;

internal class Map
{
    private List<GameObject> _mapObjects;
    private ScreenSurface _mapSurface;
    public Point WorldPosition;

    public IReadOnlyList<GameObject> GameObjects => _mapObjects.AsReadOnly();
    public ScreenSurface SurfaceObject => _mapSurface;
    public GameObject UserControlledObject { get; set; }
    public int PlayerScreen { get; set; }
    



    public Map(int mapWidth, int mapHeight)
    {

        _mapObjects = new List<GameObject>();
        _mapSurface = new ScreenSurface(mapWidth, mapHeight);
        _mapSurface.UseMouse = false;
        
        FillBackground();
        UserControlledObject = new GameObject(new ColoredGlyph(Color.AnsiMagentaBright, Color.Transparent, 2), _mapSurface.Surface.Area.Center, _mapSurface);

        _mapSurface.DrawBox(new Rectangle(3, 3, 23, 10), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Blue, Color.Black, 176)));

        
        CreateTreasure();
        CreateMonster();
        WorldPosition = (2, 2);

    }

    public void FillBackground()
    {
        
        Color[] colors = new[] { Color.LightGreen, Color.Coral, Color.CornflowerBlue, Color.DarkGreen };
        float[] colorStops = new[] { 0f, 0.35f, 0.75f, 1f };

        Algorithms.GradientFill(_mapSurface.FontSize,
                                _mapSurface.Surface.Area.Center,
                                _mapSurface.Surface.Width / 3,
                                45,
                                _mapSurface.Surface.Area,
                                new Gradient(colors, colorStops),
                                (x, y, color) => _mapSurface.Surface[x, y].Background = color);
    }

    

    private void CreateTreasure()
    {

        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                                             Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject treasure = new GameObject(new ColoredGlyph(Color.Yellow, Color.Black, 'v'), randomPosition, _mapSurface);
            _mapObjects.Add(treasure);
            break;
        }
    }
    
    public  void CreateMonster()
    {

        
        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                                                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            // If the code reaches here, we've got a good position, create the game object.
            GameObject monster = new GameObject(new ColoredGlyph(Color.Red, Color.Black, 'M'), randomPosition, _mapSurface);
            _mapObjects.Add(monster);
            break;
        }
    }

    public bool TryGetMapObject(Point position, [NotNullWhen(true)] out GameObject? gameObject)
    {
        // Try to find a map object at that position
        foreach (var otherGameObject in _mapObjects)
        {
            if (otherGameObject.Position == position)
            {
                gameObject = otherGameObject;
                return true;
            }
        }

        gameObject = null;
        return false;
    }

    public bool IsMonsterNearby(Point currentPosition)
    {
        // Define the range within which a monster is considered "nearby"
        int detectionRange = 5;

        foreach (var obj in _mapObjects)
        {
            if (obj is GameObject && ((GameObject)obj).Appearance.Glyph == 'M') // Check if the object is a monster
            {
                var monster = (GameObject)obj;
                if (Math.Abs(monster.Position.X - currentPosition.X) <= detectionRange &&
                    Math.Abs(monster.Position.Y - currentPosition.Y) <= detectionRange)
                {
                    return true;
                }
            }
        }
         
        return false;
    }

    public bool IsAtEdge(Point position, int buffer = 1)
    {
        // Get the map dimensions
        int mapHeight = _mapSurface.Height;
        int mapWidth = _mapSurface.Width;
        

        // Check if the player's position is within the buffer zone of the edge
        return position.X < buffer || position.X >= mapWidth - buffer ||
               position.Y < buffer || position.Y >= mapHeight - buffer;
    }

   

    public Point WrapAroundPosition(Point position, int buffer = 1)
    {
        int mapWidth = 120;
        int mapHeight = 30;

        //WorldPosition = (2, 2); initial coordinate is set elsewhere         

        // Adjust coordinates for buffer zone
        int adjustedX = position.X;
        int adjustedY = position.Y;

        if (position.X < buffer) //left
        {
            adjustedX = mapWidth - buffer -1;
            WorldPosition = WorldPosition - (1, 0);
            if (WorldPosition.X == -1)
            {
                WorldPosition = (5, WorldPosition.Y);
                
            }
            
        }
        else if (position.X >= mapWidth - buffer) //right
        {
            adjustedX = buffer;
            WorldPosition = WorldPosition + (1, 0);
            if (WorldPosition.X == 6)
            {
                WorldPosition = (0, WorldPosition.Y);

            }
            
        }

        if (position.Y < buffer) // top
        {
            adjustedY = mapHeight - buffer -1;
            //WorldPosition = WorldPosition - ((0, 1));
            WorldPosition = WorldPosition - (0, 1);
            if (WorldPosition.Y == -1)
            {
                WorldPosition = (WorldPosition.X, 5);
            }
            
        }
        else if (position.Y >= mapHeight - buffer)
        {
            adjustedY = buffer; //bottom
            WorldPosition = WorldPosition + (0, 1);
            if (WorldPosition.Y == 6)
            {
                WorldPosition = (WorldPosition.X, 0);
            }
            


        }

        return new Point(adjustedX, adjustedY);

        
    }



}