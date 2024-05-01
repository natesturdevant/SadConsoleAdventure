﻿using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace SadConsoleGame;

internal class Map
{
    private List<GameObject> _mapObjects;
    private ScreenSurface _mapSurface;

    public IReadOnlyList<GameObject> GameObjects => _mapObjects.AsReadOnly();
    public ScreenSurface SurfaceObject => _mapSurface;
    public GameObject UserControlledObject { get; set; }

    public Map(int mapWidth, int mapHeight)
    {
        _mapObjects = new List<GameObject>();
        _mapSurface = new ScreenSurface(mapWidth, mapHeight);
        _mapSurface.UseMouse = false;

        FillBackground();

        UserControlledObject = new GameObject(new ColoredGlyph(Color.White, Color.Black, 2), _mapSurface.Surface.Area.Center, _mapSurface);

        CreateTreasure();
        CreateMonster();
        
    }

    private void FillBackground()
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

    public void CreateConsole()
    {
        ScreenObject container = new ScreenObject();
        Game.Instance.Screen = container;

        // First console
        Console console1 = new(115, 5);
        console1.Position = (2, 32);
        console1.Surface.DefaultBackground = Color.AnsiCyan;
        console1.Clear();
        console1.Print(1, 1, "Type on me!");
        console1.Cursor.Position = (1, 2);
        console1.Cursor.IsEnabled = true;
        console1.Cursor.IsVisible = true;
        console1.Cursor.MouseClickReposition = true;
        console1.IsFocused = true;
        container.Children.Add(console1);
        
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


}