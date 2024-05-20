
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
*/
/*

using SadConsole;
using SadConsole.Components;
using SadRogue.Primitives;
using SadConsole.UI.Controls;
using System;
using SadConsole.UI;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace SadConsoleGame
{
    internal class CustomConsole : ControlsConsole
    {
        private Map map;
        private readonly ClassicConsoleKeyboardHandler _keyboardHandler;
        public event EventHandler OnConsoleClosed;
        private Dictionary<string, string> keywordMapping;
        private Dictionary<int, Dictionary<string, string>> jsonData;

        public CustomConsole(int width, int height) : base(width, height)
        {
            map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 6);
            _keyboardHandler = new ClassicConsoleKeyboardHandler("Ask about... ");
            _keyboardHandler.EnterPressedAction = EnterPressedActionHandler;
            SadComponents.Add(_keyboardHandler);
            LoadKeywordMapping();
        }

        public void LoadKeywordMapping()
        {
            try
            {
                string jsonFilePath = "C:/SAD2/Part4/ParserInput65.json"; // Path to the single JSON file
                string json = File.ReadAllText(jsonFilePath);
                jsonData = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, string>>>(json);

                map.UpdateCharGlyph();
                int charGlyph = map.charGlyph;
                if (jsonData.ContainsKey(charGlyph))
                {
                    keywordMapping = jsonData[charGlyph];
                }
                else
                {
                    keywordMapping = new Dictionary<string, string>();
                }
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
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;


namespace SadConsoleGame
{
    internal class CustomConsole : ControlsConsole
    {
        private Map map;
        private readonly ClassicConsoleKeyboardHandler _keyboardHandler;
        public event EventHandler OnConsoleClosed;
        private Dictionary<string, string> keywordMapping;
        private Dictionary<string, Dictionary<string, string>> jsonData;

        public CustomConsole(int width, int height) : base(width, height)
        {
            map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 6);
            _keyboardHandler = new ClassicConsoleKeyboardHandler("Ask about... ");
            _keyboardHandler.EnterPressedAction = EnterPressedActionHandler;
            SadComponents.Add(_keyboardHandler);
            LoadJsonData();
            UpdateKeywordMapping();
        }

        public void LoadJsonData()
        {
            try
            {
                string jsonFilePath = "C:/SAD2/Part4/ParserInput65.json"; // hardcoded ath to the JSON file
                string json = File.ReadAllText(jsonFilePath);

                // Deserialize the JSON data into a dictionary
                jsonData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            }
            catch (Exception ex)
            {
                Cursor.Print(ex.Message);
                jsonData = new Dictionary<string, Dictionary<string, string>>();
            }
        }

        public void UpdateKeywordMapping()
        {
            map.UpdateCharGlyph();
            string charGlyphKey = map.charGlyph.ToString();
           

            if (jsonData.ContainsKey(charGlyphKey))
            
            {
                keywordMapping = jsonData[charGlyphKey];
            }
            else
            {
                keywordMapping = new Dictionary<string, string>();
            }
        }

        public void EnterPressedActionHandler(ClassicConsoleKeyboardHandler keyboardComponent, Cursor cursor, string value)
        {
            UpdateKeywordMapping();
            LoadJsonData();
            string valueToLower = value.ToLower();

            if (valueToLower == "goodbye")
            {
                cursor.Print("See ya!");
                OnConsoleClosed?.Invoke(this, EventArgs.Empty);
                Game.Instance.Screen.IsFocused = true; //back to the game screen from the parser
            }
            else if (keywordMapping.ContainsKey(valueToLower))
            {
                cursor.Print(keywordMapping[valueToLower]);
            }
            else
            {
                cursor.Print("I don't understand");
            }

            cursor.NewLine();
        }
    }
}
