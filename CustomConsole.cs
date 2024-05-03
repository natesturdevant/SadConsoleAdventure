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
                    "Maybe you should ask Larry about it. " +
                    "He's dying to get in.");
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
