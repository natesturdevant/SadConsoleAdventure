using SadConsole;
using SadConsole.Components;
using SadRogue.Primitives;
using SadConsole.UI.Controls;
using System;
using SadConsole.UI;
using SadConsole.StringParser;
using Coroutine;
using SadConsole.Instructions;





namespace SadConsoleGame
{

    
    internal class CustomConsole : ControlsConsole
    {

        //YourGameClass newInstance = new YourGameClass(); 

        private readonly ClassicConsoleKeyboardHandler _keyboardHandler;
        public event EventHandler OnConsoleClosed;


        public CustomConsole(int width, int height) : base(width, height)
        {
            // Create the keyboard handler
            _keyboardHandler = new ClassicConsoleKeyboardHandler("Ask about... ");
            _keyboardHandler.EnterPressedAction = EnterPressedActionHandler;

            // Add the keyboard handler to the console
            SadComponents.Add(_keyboardHandler);
        }




        public void EnterPressedActionHandler(ClassicConsoleKeyboardHandler keyboardComponent, Cursor cursor, string value)
        {
            string valueToLower = value.ToLower();
            value = valueToLower;

            // Implement text parsing logic here
            if (value == "help")
            {
                cursor.NewLine().Print("Help INFO...");
            }

            else if (value == "computer lab")
            {
                cursor.Print("I heard that it was free tonight..." +
                    "Maybe you should ask LARRY about it. " +
                    "He's dying to get in.");
            }

            else if (value == "hello")
            {
                cursor.Print("What's good, my dude.");
            }

            else if (value == "larry")
            {
                cursor.Print("He's definitely been hanging around trying to play RACETRACK for weeks but Professor KLOBBER has that shit on lock down.");
            }

            else if (value == "racetrack")
            {
                cursor.Print("I heard you can drive all the way to CINCINNATI in that game. It's real!");
            }

            else if (value == "klobber")
            {
                cursor.Print("He's an old shoe that's for sure. I'm on his good side." +
                    "Not that it matters anymore." +
                    "I'll be out of here by this time next week." +
                    "No more KLOBBER.");
            }

            else if (value == "cincinnati")
            {
                cursor.Print("Dude, I've always wanted to go." +
                    "The land of milk and honey.");
            }

            else if (value == "goodbye")
            {
                cursor.Print("See ya!");
                OnConsoleClosed?.Invoke(this, EventArgs.Empty);
                Game.Instance.Screen.IsFocused = true;
            }

            else
            { 
                cursor.Print("I don't understand");
            }

            // Move cursor to the next line for the next input
            cursor.NewLine();
        }
    }
    

}