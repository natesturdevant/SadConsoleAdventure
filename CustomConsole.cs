/*
using SadConsole;
using SadConsole.Components;
using SadRogue.Primitives;
using SadConsole.UI.Controls;
using System;
using SadConsole.UI;
using SadConsole.StringParser;
using Coroutine;
using SadConsole.Instructions;
using Newtonsoft.Json;

*/

/*

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
        
        private Dictionary<string, string> keywordMapping;

        public ControlsConsole()
        {
            // Load your JSON data into the dictionary
            string jsonFilePath = "data.json"; // Path to your JSON file
            string json = File.ReadAllText(jsonFilePath);
            keywordMapping = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public void EnterPressedActionHandler(ClassicConsoleKeyboardHandler keyboardComponent, Cursor cursor, string value)
        {
            string valueToLower = value.ToLower();
            value = valueToLower;

            // Check if the entered value exists in the dictionary
            if (keywordMapping.ContainsKey(value))
            {
                cursor.Print(keywordMapping[value]);
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

*/

using SadConsole;
using SadConsole.Components;
using SadRogue.Primitives;
using SadConsole.UI.Controls;
using System;
using SadConsole.UI;
using SadConsole.StringParser;
using Coroutine;
using SadConsole.Instructions;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace SadConsoleGame
{
    internal class CustomConsole : ControlsConsole
    {
        private readonly ClassicConsoleKeyboardHandler _keyboardHandler;
        public event EventHandler OnConsoleClosed;

        private Dictionary<string, string> keywordMapping;

        public CustomConsole(int width, int height) : base(width, height)
        {
            // Create the keyboard handler
            _keyboardHandler = new ClassicConsoleKeyboardHandler("Ask about... ");
            _keyboardHandler.EnterPressedAction = EnterPressedActionHandler;

            // Add the keyboard handler to the console
            SadComponents.Add(_keyboardHandler);

            // Load JSON data into dictionary
            LoadKeywordMapping();
        }

        private void LoadKeywordMapping()
        {
            
            try
            {
                string jsonFilePath = "C:/SAD2/Part4/ParserInput.json"; // Path to your JSON file
                string json = File.ReadAllText(jsonFilePath);
               
                    keywordMapping = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                
            }
            catch (Exception ex)
            {
                //Console.("Error loading JSON: " + ex.Message);
                //.SurfaceObject.Print(5, 5, "Error loading JSON: " + ex.Message);
                
                keywordMapping = new Dictionary<string, string>();
            }
        }

        public void EnterPressedActionHandler(ClassicConsoleKeyboardHandler keyboardComponent, Cursor cursor, string value)
        {
            
            string valueToLower = value.ToLower();
            value = valueToLower;

            // Check if the entered value exists in the dictionary
            if (value == "goodbye")
            {
                cursor.Print("See ya!");
                OnConsoleClosed?.Invoke(this, EventArgs.Empty);
                Game.Instance.Screen.IsFocused = true;
            }

            else if (keywordMapping.ContainsKey(value))
            {
                cursor.Print(keywordMapping[value]);
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
