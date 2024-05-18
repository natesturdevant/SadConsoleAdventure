using SadConsole.Components;
using SadConsole.UI;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace SadConsoleGame;

internal class Map
{
    public List<GameObject> _mapObjects;
    private ScreenSurface _mapSurface;
    public Point WorldPosition;

    public IReadOnlyList<GameObject> GameObjects => _mapObjects.AsReadOnly();
    public ScreenSurface SurfaceObject => _mapSurface;
    public GameObject UserControlledObject { get; set; }
    public int PlayerScreen { get; set; }
    public int charGlyph { get; set; }

    //public CellSurface coloredGlyphBases;

    

    public Map(int mapWidth, int mapHeight)
    {

        _mapObjects = new List<GameObject>();
        _mapSurface = new ScreenSurface(mapWidth, mapHeight);
        _mapSurface.UseMouse = false;
        CreateMonster();
        FillBackground();
        UserControlledObject = new GameObject(new ColoredGlyph(Color.AnsiMagentaBright, Color.Transparent, 2), _mapSurface.Surface.Area.Center, _mapSurface);

        _mapSurface.DrawBox(new Rectangle(3, 3, 23, 10), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Blue, Color.Black, 176)));

        
        //CreateTreasure();
        
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
    
    public static bool FindWall(Point newPosition, Map map)
    {
        if (map.SurfaceObject.GetBackground(newPosition.X, newPosition.Y) == Color.White)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    MapDrawing mapDrawing = new MapDrawing();
    

    public  void CreateMonster()
    {

        
        // Try 1000 times to get an empty map position
        for (int i = 0; i < 1000; i++)
        {
            
            // Get a random position
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                                                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            Point randomPosition2 = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                                                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            // Check if any object is already positioned there, repeat the loop if found
            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            
            if (foundObject) continue;

            

            // If the code reaches here, we've got a good position, create the game object.
            //GameObject monster = new GameObject(new ColoredGlyph(Color.Red, Color.Black, 'M'), randomPosition, _mapSurface);
            //GameObject Carol = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'C'), randomPosition2, _mapSurface);
            




            _mapObjects.Clear();
            //_mapObjects.Add(Carol);
            //int mapIndex = WorldPosition.Y * 5 + WorldPosition.X;
            switch (WorldPosition)
            {
                case (0, 0): GameObject Anthony = new GameObject(new ColoredGlyph(Color.Red, Color.Black, 'A'), randomPosition, _mapSurface); _mapObjects.Add(Anthony);
                    charGlyph = 65; break;
                case (0, 1): GameObject Brenda = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'B'), randomPosition2, _mapSurface); _mapObjects.Add(Brenda);
                    charGlyph = 66; break;
                case (0, 2): GameObject Connie = new GameObject(new ColoredGlyph(Color.AnsiYellow, Color.Black, 'C'), randomPosition2, _mapSurface); _mapObjects.Add(Connie);
                    charGlyph = 67; break;
                case (0, 3): GameObject Dave = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'D'), randomPosition2, _mapSurface); _mapObjects.Add(Dave);
                    charGlyph = 68; break;
                case (0, 4): GameObject Evelyn = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'E'), randomPosition2, _mapSurface); _mapObjects.Add(Evelyn);
                    charGlyph = 69; break;
                case (1, 0): GameObject Fred = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'F'), randomPosition2, _mapSurface); _mapObjects.Add(Fred);
                    charGlyph = 70; break;
                case (1, 1): GameObject Gwen = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'G'), randomPosition2, _mapSurface); _mapObjects.Add(Gwen);
                    charGlyph = 71; break;
                case (1, 2): GameObject Herb = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'H'), randomPosition2, _mapSurface); _mapObjects.Add(Herb);
                    charGlyph = 72; break;
                case (1, 3): GameObject Iris = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'I'), randomPosition2, _mapSurface); _mapObjects.Add(Iris);
                    charGlyph = 73; break;
                case (1, 4): GameObject Joe = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'J'), randomPosition2, _mapSurface); _mapObjects.Add(Joe);
                    charGlyph = 74; break;
                case (2, 0): GameObject Ken = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'K'), randomPosition2, _mapSurface); _mapObjects.Add(Ken);
                    charGlyph = 75; break;
                case (2, 1): GameObject Larry = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'L'), randomPosition2, _mapSurface); _mapObjects.Add(Larry);
                    charGlyph = 76; break;
                case (2, 2): GameObject Maggie = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'M'), randomPosition2, _mapSurface); _mapObjects.Add(Maggie);
                    charGlyph = 77; break;
                case (2, 3): GameObject Nate = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'N'), randomPosition2, _mapSurface); _mapObjects.Add(Nate);
                    charGlyph = 78; break;
                case (2, 4): GameObject Ollie = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'O'), randomPosition2, _mapSurface); _mapObjects.Add(Ollie);
                    charGlyph = 79; break;
                case (3, 0): GameObject Penny = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'P'), randomPosition2, _mapSurface); _mapObjects.Add(Penny);
                    charGlyph = 80; break;
                case (3, 1): GameObject Queenie = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'Q'), randomPosition2, _mapSurface); _mapObjects.Add(Queenie);
                    charGlyph = 81; break;
                case (3, 2): GameObject Ros = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'R'), randomPosition2, _mapSurface); _mapObjects.Add(Ros);
                    charGlyph = 82; break;
                case (3, 3): GameObject Sam = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'S'), randomPosition2, _mapSurface); _mapObjects.Add(Sam);
                    charGlyph = 83; break;
                case (3, 4): GameObject Tim = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'T'), randomPosition2, _mapSurface); _mapObjects.Add(Tim);
                    charGlyph = 84; break;
                case (4, 0): GameObject Una = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'U'), randomPosition2, _mapSurface); _mapObjects.Add(Una);
                    charGlyph = 85; break;
                case (4, 1): GameObject Vicki = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'V'), randomPosition2, _mapSurface); _mapObjects.Add(Vicki);
                    charGlyph = 86; break;
                case (4, 2): GameObject William = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'W'), randomPosition2, _mapSurface); _mapObjects.Add(William);
                    charGlyph = 87; break;
                case (4, 3): GameObject Xavier = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'X'), randomPosition2, _mapSurface); _mapObjects.Add(Xavier);
                    charGlyph = 88; break;
                case (4, 4): GameObject Yvonne = new GameObject(new ColoredGlyph(Color.Cyan, Color.Black, 'Y'), randomPosition2, _mapSurface); _mapObjects.Add(Yvonne);
                    charGlyph = 89; break;

            }
                
            
            
            break;
        }
    }

 public void UpdateCharGlyph()
    {
        switch (WorldPosition)
        {
            
            case (0, 0): charGlyph = 65; break;
            case (0, 1): charGlyph = 66; break;
            case (0, 2): charGlyph = 67; break;
            case (0, 3): charGlyph = 68; break;
            case (0, 4): charGlyph = 69; break;
            case (1, 0): charGlyph = 70; break;
            case (1, 1): charGlyph = 71; break;
            case (1, 2): charGlyph = 72; break;
            case (1, 3): charGlyph = 73; break;
            case (1, 4): charGlyph = 74; break;
            case (2, 0): charGlyph = 75; break;
            case (2, 1): charGlyph = 76; break;
            case (2, 2): charGlyph = 77; break;
            case (2, 3): charGlyph = 78; break;
            case (2, 4): charGlyph = 79; break;
            case (3, 0): charGlyph = 80; break;
            case (3, 1): charGlyph = 81; break;
            case (3, 2): charGlyph = 82; break;
            case (3, 3): charGlyph = 83; break;
            case (3, 4): charGlyph = 84; break;
            case (4, 0): charGlyph = 85; break;
            case (4, 1): charGlyph = 86; break;
            case (4, 2): charGlyph = 87; break;
            case (4, 3): charGlyph = 88; break;
            case (4, 4): charGlyph = 89; break;
            /*
            case (0, 0): charGlyph = 65; return charGlyph; 
            case (0, 1): charGlyph = 66; return charGlyph; 
            case (0, 2): charGlyph = 67; return charGlyph;
            case (0, 3): charGlyph = 68; return charGlyph;
            case (0, 4): charGlyph = 69; return charGlyph;
            case (1, 0): charGlyph = 70; return charGlyph;
            case (1, 1): charGlyph = 71; return charGlyph;
            case (1, 2): charGlyph = 72; return charGlyph;
            case (1, 3): charGlyph = 73; return charGlyph;
            case (1, 4): charGlyph = 74; return charGlyph;
            case (2, 0): charGlyph = 75; return charGlyph;
            case (2, 1): charGlyph = 76; return charGlyph;
            case (2, 2): charGlyph = 77; return charGlyph;
            case (2, 3): charGlyph = 78; return charGlyph;
            case (2, 4): charGlyph = 79; return charGlyph;
            case (3, 0): charGlyph = 80; return charGlyph;
            case (3, 1): charGlyph = 81; return charGlyph;
            case (3, 2): charGlyph = 82; return charGlyph; 
            case (3, 3): charGlyph = 83; return charGlyph;
            case (3, 4): charGlyph = 84; return charGlyph;
            case (4, 0): charGlyph = 85; return charGlyph;
            case (4, 1): charGlyph = 86; return charGlyph;
            case (4, 2): charGlyph = 87; return charGlyph;
            case (4, 3): charGlyph = 88; return charGlyph;
            case (4, 4): charGlyph = 89; return charGlyph; 
               */
                
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
        //charGlyph = 0;
        // Define the range within which a monster is considered "nearby"
        int detectionRange = 3;

        foreach (var obj in _mapObjects)
        {
           // if (obj is GameObject && obj.Appearance.Glyph == 'M') // Check if the object is a monster
           if (obj is GameObject && obj.Appearance.IsVisible)
            {
                
                var monster = (GameObject)obj;
                //charGlyph = monster.Appearance.Glyph;
                if (Math.Abs(monster.Position.X - currentPosition.X) <= detectionRange &&
                    Math.Abs(monster.Position.Y - currentPosition.Y) <= detectionRange)
                {
                    //charGlyph = monster.Appearance.Glyph;
       
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
        int mapWidth = 60;
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
                WorldPosition = (4, WorldPosition.Y);
                

            }
            
        }
        else if (position.X >= mapWidth - buffer) //right
        {
            adjustedX = buffer;
            WorldPosition = WorldPosition + (1, 0);
            if (WorldPosition.X == 5)
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
                WorldPosition = (WorldPosition.X, 4);
                
            }
            
        }
        else if (position.Y >= mapHeight - buffer)
        {
            adjustedY = buffer; //bottom
            WorldPosition = WorldPosition + (0, 1);
            if (WorldPosition.Y == 5)
            {
                WorldPosition = (WorldPosition.X, 0);
                
            }
            


        }

        return new Point(adjustedX, adjustedY);

        
    }



}