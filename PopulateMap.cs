using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SadConsoleGame
{
    
    internal class PopulateMap
    {
        void populateMap(Map map)
        {
            MapDrawing mappo = new MapDrawing();
            if (mappo.mapIndex == 0)
            {
                map.CreateMonster();
            }
        }
       

    }
}
