using ColorMine.ColorSpaces;
using SadConsole;
using System.IO;
namespace SadConsoleGame;





internal class GameObject
{
    private ColoredGlyph _mapAppearance = new ColoredGlyph();
    private Map _map;
    

    public Point Position { get; private set; }

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

    /*
    public bool Move(Point newPosition, Map map)
    {
        // Check new position is valid
        if (!map.SurfaceObject.IsValidCell(newPosition.X, newPosition.Y)) return false;

        // Check if other object is there
        if (map.TryGetMapObject(newPosition, out GameObject? foundObject))
        {
            // We touched the other object, but they won't allow us to move into the space
            if (!foundObject.Touched(this, map))
                return false;
        }
         if (map.IsAtEdge(map.UserControlledObject.Position))
        {
            map.SurfaceObject.Clear(); //this should be a function which clears and re-draws the screen based on player's position in the world.
            

        }
      

            // Restore the old cell
            _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);

        // Store the map cell of the new position
        map.SurfaceObject.Surface[newPosition].CopyAppearanceTo(_mapAppearance);

        Position = newPosition;
        DrawGameObject(map.SurfaceObject);

        return true;
    }
    */ //^^^THE OLD ONE THAT WORKS
    /*
    public bool Move(Point newPosition, Map map)
    {
        // Check new position is valid
        if (!map.SurfaceObject.IsValidCell(newPosition.X, newPosition.Y)) return false;

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
            // If so, wrap around to the opposite end
            map.UserControlledObject.Position = map.WrapAroundPosition(newPosition);
            //map.UserControlledObject.Move(_map.UserControlledObject.Position -10, map);
            // Redraw the game screen to reflect the updated position
            map.SurfaceObject.IsDirty = true;

        }

        // Restore the old cell
        _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);

        // Store the map cell of the new position
        map.SurfaceObject.Surface[newPosition].CopyAppearanceTo(_mapAppearance);

        Position = newPosition;
        DrawGameObject(map.SurfaceObject);

        return true;
    }
    */

    public bool Move(Point newPosition, Map map)
    {
        // Check new position is valid
        if (!map.SurfaceObject.IsValidCell(newPosition.X, newPosition.Y)) return false;

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

            //map.UserControlledObject.DrawGameObject(map.SurfaceObject);
            DrawGameObject(map.SurfaceObject);

            //_map.SurfaceObject.Print(0,0"Player moved to: {Position} (after wrapping)"); // Debug logging
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