

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
using System.Security.AccessControl;

namespace SadConsoleGame
{

    
    internal class CustomConsole : ControlsConsole
    {
        private Map map;
        private readonly ClassicConsoleKeyboardHandler _keyboardHandler;
        public event EventHandler OnConsoleClosed;

        private Dictionary<string, string> keywordMapping;

      
        
        



        public CustomConsole(int width, int height) : base(width, height)
        {
            
            map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 6);
            // Create the keyboard handler
            _keyboardHandler = new ClassicConsoleKeyboardHandler("Ask about... ");
            _keyboardHandler.EnterPressedAction = EnterPressedActionHandler;
            
            // Add the keyboard handler to the console
            SadComponents.Add(_keyboardHandler);

            // Load JSON data into dictionary
          LoadKeywordMapping();    
        }

        public void LoadKeywordMapping()
        {

            
            
            try
            {
                map.UpdateCharGlyph();
                string jsonFilePath = $"C:/SAD2/Part4/ParserInput{map.charGlyph}.json"; // Path to JSON file
                //string jsonFilePath = "C:/SAD2/Part4/ParserInput65.json"; // Path to JSON file --- hardcoded  ---
                string json = File.ReadAllText(jsonFilePath);
                keywordMapping = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                
                
                    
                

            }
            catch (Exception ex)
            {
                
                Cursor.Print(ex.Message);
                keywordMapping = new Dictionary<string, string>();
            }
        }
        

        public void EnterPressedActionHandler(ClassicConsoleKeyboardHandler keyboardComponent, Cursor cursor, string value)
        {
            map.UpdateCharGlyph();
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
