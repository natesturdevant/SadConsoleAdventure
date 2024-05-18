using ColorMine.ColorSpaces;
using SadConsole;
using System.IO;
namespace SadConsoleGame;





internal class GameObject
{
    private ColoredGlyph _mapAppearance = new ColoredGlyph();
    private Map _map;
    Console _debugger = new Console(10, 10);
    public Map map;
    
    public Point Position { get; private set; }
    private MapDrawing mapDraw = new MapDrawing(); // Instantiate MapDrawing object
    public ColoredGlyph Appearance { get; set; }

    public GameObject(ColoredGlyph appearance, Point position, IScreenSurface hostingSurface)
    {
        Appearance = appearance;
        Position = position;

        // Store the map cell
        hostingSurface.Surface[position].CopyAppearanceTo(_mapAppearance);

        // draw the object
        DrawGameObject(hostingSurface);
    }

    private void DrawGameObject(IScreenSurface screenSurface)
    {
        Appearance.CopyAppearanceTo(screenSurface.Surface[Position]);
        screenSurface.IsDirty = true;
    }

    bool FindWall(Point newPosition, Map map)
    {


        if (map.SurfaceObject.GetBackground(newPosition.X, newPosition.Y) == Color.White)
        {
            return true;
        }

        else { return false; }
    }

    public void PartnerFollow()
    {
        //add partner following logic
    }
    
    public bool Move(Point newPosition, Map map)
    {
        
        
        // Check new position is valid
        if (!map.SurfaceObject.IsValidCell(newPosition.X, newPosition.Y)) return false;

        if (FindWall(newPosition, map)) 
        {
            return false;
        }
       

        // Check if other object is there
        if (map.TryGetMapObject(newPosition, out GameObject? foundObject))
        {
            // We touched the other object, but they won't allow us to move into the space
            if (!foundObject.Touched(this, map))
                return false;
        }
       
        // Check if the new position is at the edge of the map
        if (map.IsAtEdge(newPosition))
        {
            newPosition = map.WrapAroundPosition(newPosition);
            // Clear the old player position before wrapping
            _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);
            map.SurfaceObject.Surface[Position].CopyAppearanceTo(map.UserControlledObject._mapAppearance);

            // Wrap around to the opposite end
            map.UserControlledObject.Position = map.WrapAroundPosition(newPosition);
            _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[newPosition]);
            
            Position = newPosition;
            // Update player's visuals on the screen
            
            mapDraw.drawMaps(map);
            map.CreateMonster();
            DrawGameObject(map.SurfaceObject);
            
            
            


        }
        else
        {
            // Restore the old cell (same as before)
            _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);

            // Store the map cell of the new position (same as before)
            map.SurfaceObject.Surface[newPosition].CopyAppearanceTo(_mapAppearance);

            Position = newPosition;
            DrawGameObject(map.SurfaceObject);
        }

       
        return true;
    }
    public virtual bool Touched(GameObject source, Map map)
    {
        return false;
    }
}